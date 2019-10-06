using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using BLL.ServiceImplementation;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace BLL.Tests.ServiceImplementation
{
    [TestFixture]
    class AccountServiceTests
    {
        [Test]
        public void Ctor_RepositoryIsNull_ThrowsArgumentNullException()
        {
            var accountFactory = new Mock<IAccountFactory>().Object;
            Assert.Throws<ArgumentNullException>(() => new AccountService(null, accountFactory));
        }

        [Test]
        public void Ctor_AcountFactoryIsNull_ThrowsArgumentNullException()
        {
            var accountRepository = new Mock<IAccountRepository>().Object;
            Assert.Throws<ArgumentNullException>(() => new AccountService(accountRepository, null));
        }

        [Test]
        public void OpenAccount_OwnerNameIsNull_ThrowsArgumentException()
        {
            var accountRepository = new Mock<IAccountRepository>().Object;
            var accountFactory = new Mock<IAccountFactory>().Object;
            var service = new AccountService(accountRepository, accountFactory);
            var creator = new Mock<IAccountNumberCreateService>().Object;

            Assert.Throws<ArgumentException>(() => service.OpenAccount(null, "BaseAccount", creator));
        }

        [Test]
        public void OpenAccount_OwnerNameIsEmpty_ThrowsArgumentException()
        {
            var accountRepository = new Mock<IAccountRepository>().Object;
            var accountFactory = new Mock<IAccountFactory>().Object;
            var service = new AccountService(accountRepository, accountFactory);
            var creator = new Mock<IAccountNumberCreateService>().Object;

            Assert.Throws<ArgumentException>(() => service.OpenAccount(string.Empty, "BaseAccount", creator));
        }

        [Test]
        public void OpenAccount_CreatorIsNull_ThrowsArgumentNullException()
        {
            var accountRepository = new Mock<IAccountRepository>().Object;
            var accountFactory = new Mock<IAccountFactory>().Object;
            var service = new AccountService(accountRepository, accountFactory);

            Assert.Throws<ArgumentNullException>(() => service.OpenAccount("TestOwner", "BaseAccount", null));
        }

        [TestCase("John Doe", "BaseAccount")]
        [TestCase("John Skeet", "SilverAccount")]
        [TestCase("Doe Je", "BaseAccount")]
        public void OpenAccountTest_CreatesCorrectInstance(string ownerName, string accountType)
        {
            var accountRepository = new Mock<IAccountRepository>();
            var accountFactory = new Mock<IAccountFactory>();
            accountFactory.Setup(f => f.GetInstance("BaseAccount")).Returns(new BaseAccount());
            accountFactory.Setup(f => f.GetInstance("SilverAccount")).Returns(new SilverAccount());
            var service = new AccountService(accountRepository.Object, accountFactory.Object);
            var accountNumberCreator = new Mock<IAccountNumberCreateService>();
            accountNumberCreator.Setup(nc => nc.GetNextNumber()).Returns("ConcreteNumber");

            service.OpenAccount(ownerName, accountType, accountNumberCreator.Object);

            accountRepository.Verify(r => r.Create(It.Is<AccountDto>(account =>
                account.AccountNumber == "ConcreteNumber" &&
                account.AccountType == accountType &&
                account.Owner.FirstName == ownerName)));
        }

        [Test]
        public void CloseAccount_AccountCloses()
        {
            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(r => r.Get(It.IsAny<string>())).Returns(new AccountDto() { Status = "Active", AccountType = "BaseAccount", Owner = new AccountOwnerDto() });
            var accountFactory = new Mock<IAccountFactory>();
            accountFactory.Setup(f => f.GetInstance(It.IsAny<string>())).Returns(new BaseAccount());
            var service = new AccountService(accountRepository.Object, accountFactory.Object);

            service.CloseAccount("Any string");

            accountRepository.Verify(r => r.Update(It.Is<AccountDto>(account => account.Status == "Closed")));
        }


    }
}
