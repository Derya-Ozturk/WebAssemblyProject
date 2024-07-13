using Core;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        public Task<PaginationList<OrderDto>> OrderList(OrderDto orderDto);
        public Task<List<SalesRepresentiveDto>> SalesRepresentiveList();
        public Task<List<CustomerDto>> CustomerList();
        public Task<List<UserDto>> UserList();
    }
}
