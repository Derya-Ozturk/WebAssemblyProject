using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILoginService
    {
        Task<UserDto> Authenticate(string mail, string password, string audience, string issuer, string secret);
    }
}
