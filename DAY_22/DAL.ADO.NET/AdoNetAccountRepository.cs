using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.ADO.NET.Mappers;

namespace DAL.ADO.NET
{
    public class AdoNetAccountRepository : IAccountRepository
    {
        private readonly string connectionString;

        public AdoNetAccountRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Create(AccountDto entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "AddAccount";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter numberParameter = new SqlParameter("@Number", value: entity.AccountNumber);
                    command.Parameters.Add(numberParameter);
                    SqlParameter firstNameParameter = new SqlParameter("@OwnerFirstName", value: entity.Owner.FirstName);
                    command.Parameters.Add(firstNameParameter);
                    SqlParameter typeParameter = new SqlParameter("@AccountType", value: entity.AccountType);
                    command.Parameters.Add(typeParameter);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Delete(string key)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = $"DELETE FROM Accounts WHERE Number = {key}";
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public AccountDto Get(string key)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = $"SELECT * FROM Accounts JOIN AccountOwners ON Accounts.OwnerId = AccountOwners.Id JOIN AccountTypes ON Accounts.AccountTypeId = AccountTypes.Id WHERE Number = {key}";
                var command = new SqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();

                    return dataReader.ToAccountDto();
                }

                return null;
            }
        }

        public IEnumerable<AccountDto> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Accounts JOIN AccountOwners ON Accounts.OwnerId = AccountOwners.Id JOIN AccountTypes ON Accounts.AccountTypeId = AccountTypes.Id";
                var command = new SqlCommand(query, connection);
             
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    yield return dataReader.ToAccountDto();
                }
            }
        }

        public void Update(AccountDto entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE Accounts SET Balance = @Balance, BonusPoints = @BonusPoints, Status = @Status WHERE Number = @AccountNumber";
                SqlParameter numberParameter = new SqlParameter("@AccountNumber", value: entity.AccountNumber);
                command.Parameters.Add(numberParameter);
                SqlParameter balanceParameter = new SqlParameter("@Balance", value: entity.Balance);
                command.Parameters.Add(balanceParameter);
                SqlParameter bonusPointsParameter = new SqlParameter("@BonusPoints", value: entity.BonusPoints);
                command.Parameters.Add(bonusPointsParameter);
                SqlParameter statusParameter = new SqlParameter("@Status", value: entity.Status);
                command.Parameters.Add(statusParameter);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateMany(IEnumerable<AccountDto> accounts)
        {
            throw new NotImplementedException();
        }
    }
}
