using System;
using System.Linq;
using Bank.Library.Account;
using Bank.Library.Entities.AccountСapability;
using Bank.Library.Service;
using BLL.ServiceImplementation;
using DependencyResolver;
using Ninject;
using NLog;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            IAccountService service = new Service();
            service.CreateAccount(new AccountNumberGenerator(), new AccountHolder("Vasya", "Pupkin", "vasya123@rambler.ru"), AccountType.Base, out string id);
            Console.WriteLine(((Service)service).GetInfo(int.Parse(id)));
            service.AddMoney(int.Parse(id), 1000);
            Console.WriteLine(((Service)service).GetInfo(int.Parse(id)));
            service.WithdrawMoney(int.Parse(id), 500);
            Console.WriteLine(((Service)service).GetInfo(int.Parse(id)));
            try
            {
                service.CloseAccount(int.Parse(id));
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
            }

            Console.WriteLine(((Service)service).GetInfo(int.Parse(id)));

            try
            {
                service.CloseAccount(int.Parse(id));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                service.WithdrawMoney(int.Parse(id), 50000);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            service.CreateAccount(new AccountNumberGenerator(), new AccountHolder("Petya", "Ivanov", "petya123@rambler.ru"), AccountType.Gold, out string id2);
            Console.WriteLine(((Service)service).GetInfo(int.Parse(id)));
            service.AddMoney(int.Parse(id2), 1_000_000);
            Console.WriteLine(((Service)service).GetInfo(int.Parse(id)));
            service.WithdrawMoney(int.Parse(id2), 500);
            Console.WriteLine(((Service)service).GetInfo(int.Parse(id)));
            service.WithdrawMoney(int.Parse(id2), 1_000_000);
            Console.WriteLine(((Service)service).GetInfo(int.Parse(id)));

            Console.ReadLine();
        }
    }
}