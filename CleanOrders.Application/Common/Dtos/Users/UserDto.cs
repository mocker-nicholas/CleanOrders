using static OrdersDomain.Core.Enums.RoleEnums;

namespace CleanOrders.Application.Common.Dtos.Users
{
    public class UserDto
    {
        public string AccountId { get; set; }
        public string EmailAddress { get; set; }
        public Role RoleId { get; set; }
    }
}
