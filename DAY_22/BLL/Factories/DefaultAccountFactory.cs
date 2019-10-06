using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL.Factories
{
    public class DefaultAccountFactory : IAccountFactory
    {
        public Account GetInstance(string accountType)
        {
            switch (accountType)
            {
                case "BaseAccount":
                    return new BaseAccount();
                case "SilverAccount":
                    return new SilverAccount();
                case "GoldAccount":
                    return new GoldAccount();
                default:
                    throw new ArgumentException("Unknown account type.", nameof(accountType));
            }
        }
    }
}
