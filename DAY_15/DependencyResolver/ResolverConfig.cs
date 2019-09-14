using Bank.Library.AccountTypes;
using Bank.Library.Entities.AccountСapability;
using DAL.Fake;
using DAL.Interface.Interfaces;
using Ninject;
using Bank.Library.Interfaces;
using Bank.Library.Service;
using BLL.ServiceImplementation;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<Service>();
            kernel.Bind<IRepository<BankAccount>>().To<FakeRepository>();
            //kernel.Bind<IRepository>().To<AccountBinaryRepository>().WithConstructorArgument("test.bin");
            kernel.Bind<IAccountNumberGenerator>().To<AccountNumberGenerator>().InSingletonScope();
            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
