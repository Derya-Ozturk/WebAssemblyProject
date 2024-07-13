using Entities.Entities;

namespace Entities.Dtos
{
    public class OrderDto : IDto
    {
        public int? OrderNo { get; set; }
        public int? OrderStatusNo { get; set; }
        public int? SalesRepresentiveId { get; set; }
        //public string? SalesRepresentiveAbbr { get; set; }
        public int? CustomerNo { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? CustomerRequestDate { get; set; }
        public DateTime? RevisedDueDate { get; set; }
        public int? CreatorId { get; set; }
        public virtual User? Creator { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual OrderStatus? OrderStatus { get; set; }
        public virtual SalesRepresentive? SalesRepresentive { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }



}
