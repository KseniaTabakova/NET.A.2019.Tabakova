using System;
using System.Data.Entity;
using BLL.Factories;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.EF;
using Ninject;
using Ninject.Extensions.Factory;
using Logging;
using ORM;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>();
            //kernel.Bind<IRepository>().To<AccountBinaryRepository>().WithConstructorArgument("test.bin");
            kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InSingletonScope();
            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
            kernel.Bind<DbContext>().To<BankModel>();
            kernel.Bind<IAccountFactory>().To<DefaultAccountFactory>();
            kernel.Bind<ILogger>().To<NLogAdapter>();
        }
    }

}
