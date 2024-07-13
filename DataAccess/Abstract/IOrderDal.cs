using Core;
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
    public interface IOrderDal : IEntityRepository<Order>
    {
        Task<PaginationList<Order>> GetOrderList(OrderDto orderDto);
        Task<List<SalesRepresentive>> SalesRepresentiveList();
        Task<List<Customer>> CustomerList();
        Task<List<User>> UserList();


    }
}
