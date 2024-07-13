using AutoMapper;
using Business.Abstract;
using Core;
using DataAccess.Abstract;
using Entities.Dtos;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IMapper _mapper;
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal, IMapper mapper)
        {
            _orderDal = orderDal;
            _mapper = mapper;
        }
     
        public async Task<PaginationList<OrderDto>> OrderList(OrderDto orderDto)
        {
            var orderList = await _orderDal.GetOrderList(orderDto);

            var dtoList = _mapper.Map<List<OrderDto>>(orderList.Data);

            PaginationList<OrderDto> paginationList = new(dtoList, orderDto.PageNumber, orderDto.PageSize, orderList.TotalRecords);

            return paginationList;

        }

        public async Task<List<SalesRepresentiveDto>> SalesRepresentiveList()
        {
            var salesRepresentiveList = await _orderDal.SalesRepresentiveList();

            var dtoList = _mapper.Map<List<SalesRepresentiveDto>>(salesRepresentiveList);

            return dtoList;
        }

        public async Task<List<CustomerDto>> CustomerList()
        {
            var customerList = await _orderDal.CustomerList();

            var dtoList = _mapper.Map<List<CustomerDto>>(customerList);

            return dtoList;
        }

        public async Task<List<UserDto>> UserList()
        {
            var userList = await _orderDal.UserList();

            var dtoList = _mapper.Map<List<UserDto>>(userList);

            return dtoList;
        }
    }
}
