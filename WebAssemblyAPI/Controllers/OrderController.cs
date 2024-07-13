using Business.Abstract;
using Core;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace WebAssemblyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        private IMemoryCache _cache;
        public OrderController(IOrderService orderService, IMemoryCache cache)
        {
            _orderService = orderService;
            _cache = cache;
        }

        [HttpPost("orderList")]
        public async Task<ActionResult<PaginationList<OrderDto>>> GetOrderList(OrderDto orderDto)
        {
            try
            {
                return await _orderService.OrderList(orderDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("salesRepresentiveList")]
        public async Task<ActionResult<List<SalesRepresentiveDto>>> SalesRepresentiveList()
        {
            try
            {
                return await _orderService.SalesRepresentiveList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("customerList")]
        public async Task<ActionResult<List<CustomerDto>>> CustomerList()
        {
            try
            {
                return await _orderService.CustomerList();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("userList")]
        public async Task<ActionResult<List<UserDto>>> UserList()
        {
            try
            {
                return await _orderService.UserList();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
