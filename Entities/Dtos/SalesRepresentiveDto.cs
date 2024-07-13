using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class SalesRepresentiveDto: IDto
    {
        public int SalesRepresentiveId { get; set; }
        public string? SalesRepresentiveName { get; set; }
        public string? SalesRepresentiveAbbr { get; set; }
        public string? PersonImage { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
