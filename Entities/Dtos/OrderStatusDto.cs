using Entities.Entities;

namespace Entities.Dtos
{
    public class OrderStatusDto : IDto
    {
        public int OrderStatusNo { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
