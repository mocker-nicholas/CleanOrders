using System.ComponentModel.DataAnnotations;
using static OrdersDomain.Core.Enums.RoleEnums;

namespace CleanOrders.API.ApiDtos.Users
{
    public class ApiUserDto
    {
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public Role RoleId { get; set; }
    }
}
