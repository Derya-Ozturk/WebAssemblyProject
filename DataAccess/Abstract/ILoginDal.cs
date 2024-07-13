using Core.DataAccess;
using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILoginDal
    {
       Task<User> Authenticate(string mail, string password);
    }
}
