using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BaseAccount : Account
    {
        public BaseAccount()
        {
            minBalance = -100m;
            BalanceCost = 1;
            DepositCost = 1;
        }

        protected int BalanceCost { get; set; }

        protected int DepositCost { get; set; }

        protected override int CalculateAddedBonusPoints(decimal depositValue)
        {
            return base.CalculateAddedBonusPoints(depositValue);
        }

        protected override int CalculateRemovedBonusPoints(decimal withdrawValue)
        {
            return base.CalculateRemovedBonusPoints(withdrawValue);
        }
    }
}
