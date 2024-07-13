using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities;

public partial class User: IEntity
{
    [Key]
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? PersonImage { get; set; }
    public string? Mail { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
