using Bank.Library.Account;
using Bank.Library.Exceptions;
using Bank.Library.Service;
using System;

namespace Bank.Application
{
    class Program
    {
        static void Main(string[] args)
        {

            AccountService bank = new AccountService();

            AccountHolder client = new AccountHolder("ksenia", "tabova", "+375 29 666 66 66");
            AccountHolder client2 = new AccountHolder("Dana", "sidorova", "80 11 666 66 66");
            AccountHolder client3 = new AccountHolder("Anton", "reu666t", "80 29 666 66 66");
            bank.CreateAccount(client, AccountType.Gold, 5000);


            try
            {
                bank.CreateAccount(client2, AccountType.Base, 30);
            }

            catch (InvalidPhoneNumberException e)
            {
                Console.WriteLine(e.message);
            }

            try
            {
                bank.CreateAccount(client3, AccountType.Premium, 30000);
            }
            catch (InvalidNameException e)
            {
                Console.WriteLine(e.message);
            }

            bank.CloseAccount(1);

            try
            {
                bank.CloseAccount(15);
            }
            catch (AccountNotExistsException e)
            {
                Console.WriteLine(e.message);
            }

            bank.AddMoney(2, 600);
            bank.WithdrawMoney(3, 7999999);
            try
            {
                bank.WithdrawMoney(1, -6666);
            }
            catch (NegativeSumException e)
            {
                Console.WriteLine(e.message);
            }
            bank.GetAllAccounts();
           
        }
    }
}
