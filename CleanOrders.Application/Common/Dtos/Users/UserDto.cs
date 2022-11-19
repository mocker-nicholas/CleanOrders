using OrdersDomain.Core.Aggregates.Entities.Users;
using static OrdersDomain.Core.Enums.RoleEnums;

namespace CleanOrders.Application.Common.Dtos.Users
{
    public class UserDto
    {
        public UserDto(User user)
        {
            AccountId = user.AccountId;
            Email = user.Email;
            RoleId = user.RoleId;
        }
        public string AccountId { get; set; }
        public string Email { get; set; }
        public Role RoleId { get; set; }
    }
}
