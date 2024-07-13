using Entities.Entities;
using Microsoft.AspNetCore.Components;

namespace Entities.Dtos
{
    public class UserDto : IDto
    {
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? PersonImage { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
        public bool? AuthenticateResult { get; set; }
        public string? AuthToken { get; set; }      
        public DateTime? AccessTokenExpireDate { get; set; }
        public string? RefreshToken { get; set; }

    }
}
