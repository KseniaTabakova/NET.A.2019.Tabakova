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
            try
            {
                AccountHolder client = new AccountHolder("ksenia", "tabakova", "+375 29 666 66 66");
                AccountHolder client2 = new AccountHolder("ksenia", "tabakova", "29 666 66 66");
                AccountService bank = new AccountService();
                bank.CreateAccount(client, AccountType.Gold, 5000);
                bank.CreateAccount(client2, AccountType.Base, 50);

                bank.CloseAccount(1);
                bank.AddMoney(2, 600);
                foreach (var r in bank.GetAllAccounts())
                    Console.WriteLine(r);

            }
            catch (InvalidNameException e)
            {
                Console.WriteLine(e.message);
            }
            catch (InvalidPhoneNumberException e)
            {
                Console.WriteLine(e.message);
            }
            catch (NegativeSumException e)
            {
                Console.WriteLine(e.message);
            }
            catch (AccountAlreadyExistsException e)
            {
                Console.WriteLine(e.message);
            }
            catch (AccountNotExistsException e)
            {
                Console.WriteLine(e.message);
            }


        }
    }
}
