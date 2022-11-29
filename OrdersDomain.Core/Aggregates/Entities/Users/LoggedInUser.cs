using OrdersDomain.Core.Aggregates.Entities.Bases;
using System.ComponentModel.DataAnnotations;

namespace OrdersDomain.Core.Aggregates.Entities.Users
{
    public class LoggedInUser : BaseEntity
    {
        public LoggedInUser(string accountId, string email, string roleId)
        {
            AccountId = accountId;
            Email = email;
            RoleId = roleId;
        }
        public string AccountId { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string RoleId { get; set; } = "";
    }
}
