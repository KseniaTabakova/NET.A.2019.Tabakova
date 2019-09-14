using Bank.Library.AccountTypes;
using DAL.Interface.DTO;
using System;

namespace BLL
{
    public static class BllEntityMappers
    {
        //public static AccountHolder ToAccBll(this AccountHolderDTO userEntity)
        //{
        //    //return new AccountHolder()
        //    //{
        //        //TO DO
        //    //};
        //}

        public static BankAccountDTO ToAccDTO(this BankAccount dalAcc)
        {
            return new BankAccountDTO()
            {
                Id = dalAcc.Id,
                Status = dalAcc.Status,
                BonusPoints = dalAcc.Bonus,
                Person = dalAcc.Person
            };
        }

    }
}
