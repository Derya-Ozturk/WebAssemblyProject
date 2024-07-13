using Entities.Entities;

namespace Entities.Dtos
{
    public class CustomerDto: IDto
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
