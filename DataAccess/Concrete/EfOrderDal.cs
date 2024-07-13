using Core;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, OkdbContext>, IOrderDal
    {
        private readonly OkdbContext _context;

        public EfOrderDal()
        {
            _context = new OkdbContext();
        }

        public async Task<PaginationList<Order>> GetOrderList(OrderDto orderDto)
        {
            IQueryable<Order> orderQuery = _context.Orders
                .Include(x => x.Creator)
                .Include(x => x.Customer)
                .Include(x => x.OrderStatus)
                .Include(x => x.SalesRepresentive).AsNoTracking();


            if (!string.IsNullOrEmpty(orderDto.OrderNo.ToString()))
            {
                orderQuery = orderQuery.Where(x => x.OrderNo == orderDto.OrderNo);
            }

            //İlk null kontrolü giriş sayfasında hata vermemesi için. Search metodunda zaten new'lendiği için null gelmeyecek, o nedenle SalesRepresentiveName üzerinden tekrar null kontrolü yapıyoruz.
            if (orderDto.SalesRepresentive != null && orderDto.SalesRepresentive.SalesRepresentiveName != null)
            {
                orderQuery = orderQuery.Where(x => x.SalesRepresentive.SalesRepresentiveName == orderDto.SalesRepresentive.SalesRepresentiveName);
            }

            if (orderDto.Customer != null && orderDto.Customer.CustomerName != null)
            {
                orderQuery = orderQuery.Where(x => x.Customer.CustomerName == orderDto.Customer.CustomerName);

            }

            if (orderDto.Creator != null && orderDto.Creator.UserName != null)
            {
                orderQuery = orderQuery.Where(x => x.Creator.UserName == orderDto.Creator.UserName);

            }

            if (!string.IsNullOrEmpty(orderDto.CreateDate.ToString()))
            {
                orderQuery = orderQuery.Where(x => x.CreateDate == orderDto.CreateDate);
            }

            if (!string.IsNullOrEmpty(orderDto.CustomerRequestDate.ToString()))
            {
                orderQuery = orderQuery.Where(x => x.CustomerRequestDate == orderDto.CustomerRequestDate);
            }

            var orders = await orderQuery
                .Skip((orderDto.PageNumber - 1) * orderDto.PageSize)
                .Take(orderDto.PageSize)
                .ToListAsync();

            var pagedResponse = new PaginationList<Order>(orders, orderDto.PageNumber, orderDto.PageSize, orderQuery.Count());

            return pagedResponse;
        }

        public async Task<List<SalesRepresentive>> SalesRepresentiveList()
        {
            var list = await _context.SalesRepresentives.ToListAsync();

            return list;
        }

        public async Task<List<Customer>> CustomerList()
        {
            var list = await _context.Customers.ToListAsync();

            return list;
        }

        public async Task<List<User>> UserList()
        {
            var list = await _context.Users.ToListAsync();

            return list;
        }


    }
}
