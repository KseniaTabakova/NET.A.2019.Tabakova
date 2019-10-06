using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IAccountService service = resolver.Get<IAccountService>();
            IAccountNumberCreateService accountNumberCreator = resolver.Get<IAccountNumberCreateService>();
            IAccountFactory accountFactory = resolver.Get<IAccountFactory>();

            //service.OpenAccount("Account owner 1", "BaseAccount", accountNumberCreator);
            //service.OpenAccount("Account owner 2", "BaseAccount", accountNumberCreator);
            //service.OpenAccount("Account owner 3", "SilverAccount", accountNumberCreator);
            //service.OpenAccount("Account owner 4", "BaseAccount", accountNumberCreator);

            var creditNumbers = service.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

            foreach (var t in creditNumbers)
            {
                service.DepositAccount(t, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            foreach (var t in creditNumbers)
            {
                service.WithdrawAccount(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
