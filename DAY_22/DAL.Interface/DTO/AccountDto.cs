using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class AccountDto
    {
        public string AccountNumber { get; set; }

        public string AccountType { get; set; }

        public AccountOwnerDto Owner { get; set; }

        public decimal Balance { get; set; }

        public int BonusPoints { get; set; }

        public string Status { get; set; }
    }
}
