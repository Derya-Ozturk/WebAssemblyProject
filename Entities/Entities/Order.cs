using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities;

public partial class Order: IEntity
{
    [Key]
    public int OrderNo { get; set; }

    public int? OrderStatusNo { get; set; }

    public int? SalesRepresentiveId { get; set; }

    public int? CustomerNo { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? CustomerRequestDate { get; set; }

    public DateTime? RevisedDueDate { get; set; }

    public int? CreatorId { get; set; }

    public virtual User? Creator { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual OrderStatus? OrderStatus { get; set; }

    public virtual SalesRepresentive? SalesRepresentive { get; set; }
}
