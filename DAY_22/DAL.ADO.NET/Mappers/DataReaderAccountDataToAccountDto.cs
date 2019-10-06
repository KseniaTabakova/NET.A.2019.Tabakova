using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ADO.NET.Mappers
{
    public static class DataReaderAccountDataToAccountDto
    {
        public static AccountDto ToAccountDto(this SqlDataReader dataReader)
        {
            var account = new AccountDto()
            {
                AccountNumber = (string)dataReader["Number"],
                AccountType = (string)dataReader["Name"],
                Owner = new AccountOwnerDto
                {
                    FirstName = (string)dataReader["FirstName"]
                },
                Balance = (decimal)dataReader["Balance"],
                BonusPoints = (int)dataReader["BonusPoints"],
                Status = (string)dataReader["Status"]
            };

            if (!dataReader.IsDBNull(8))
            {
                account.Owner.LastName = (string)dataReader["LastName"];
            }

            if (!dataReader.IsDBNull(9))
            {
                account.Owner.Email = (string)dataReader["Email"];
            }

            return account;
        }
    }
}
