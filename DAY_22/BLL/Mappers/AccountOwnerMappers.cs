using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class AccountOwnerMappers
    {
        public static AccountOwnerDto ToAccountOwnerDto(this AccountOwner accountOwner) =>
            new AccountOwnerDto()
            {
                Email = accountOwner.Email,
                FirstName = accountOwner.FirstName,
                LastName = accountOwner.LastName
            };

        public static AccountOwner ToAccountOwner(this AccountOwnerDto accountOwnerDto) =>
            new AccountOwner()
            {
                Email = accountOwnerDto.Email,
                FirstName = accountOwnerDto.FirstName,
                LastName = accountOwnerDto.LastName
            };
    }
}
