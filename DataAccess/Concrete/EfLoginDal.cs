using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfLoginDal : EfEntityRepositoryBase<Order, OkdbContext>, ILoginDal
    {
        private readonly OkdbContext _context;

        public EfLoginDal()
        {
            _context = new OkdbContext();
        }

        public async Task<User> Authenticate(string mail, string password)
        {
            var userInfo = await _context.Users.SingleOrDefaultAsync(x => x.Mail == mail && x.Password == password);

            if (userInfo == null)
                return null;

            return userInfo;
        }
    }
}
