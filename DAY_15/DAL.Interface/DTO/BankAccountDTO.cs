
using Bank.Library.Account;

namespace DAL.Interface.DTO
{
    public class BankAccountDTO
    {
        public int Id { get; set; }
        public AccountStatus Status { get; set; }
        public int BonusPoints { get; set; }
        protected int Balance { get; set; }
        public AccountHolder Person { get; set; }

        public BankAccountDTO(int id, AccountStatus status, int bonus, int balance, AccountHolder holder )
        {
            Id = id;
            Status = status;
            BonusPoints = bonus;
            Balance = balance;
            Person = holder;
        }
    }
}
