using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IAccountRepository : IRepository<AccountDto, string>
    {
        void UpdateMany(IEnumerable<AccountDto> accounts);
    }
}
