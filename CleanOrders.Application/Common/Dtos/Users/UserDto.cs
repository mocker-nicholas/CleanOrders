using OrdersDomain.Core.Aggregates.Entities.Users;
using static OrdersDomain.Core.Enums.RoleEnums;

namespace CleanOrders.Application.Common.Dtos.Users
{
    public class UserDto
    {
        public UserDto(User user)
        {
            Id = user.Id;
            Email = user.Email;
            RoleId = user.RoleId;
        }
        public string Id { get; set; }
        public string Email { get; set; }
        public Role RoleId { get; set; }
    }
}
