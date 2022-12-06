using OrdersDomain.Core.Aggregates.Entities.Bases;
using System.ComponentModel.DataAnnotations;

namespace OrdersDomain.Core.Aggregates.Entities.Users
{
    public class LoggedInUser : BaseEntity
    {
        public LoggedInUser(string accountId, string id, string email, string roleId)
        {
            AccountId = accountId;
            Id = id;
            Email = email;
            RoleId = roleId;
        }
        public string AccountId { get; set; }
        public string Id { get; set; } = "";
        public string Email { get; set; } = "";
        [Required]
        public string RoleId { get; set; } = "";
    }
}
