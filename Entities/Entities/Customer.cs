using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities;

public partial class Customer : IEntity
{
    [Key]
    public int CustomerNo { get; set; }

    public string? CustomerName { get; set; }

    public string? BillingAddress { get; set; }

    public string? ShippingAddress { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
