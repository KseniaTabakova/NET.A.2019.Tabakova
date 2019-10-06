using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Fake
{
    public static class FakeStorage
    {
        public static List<AccountDto> Items { get; set; } = new List<AccountDto>();
    }
}
