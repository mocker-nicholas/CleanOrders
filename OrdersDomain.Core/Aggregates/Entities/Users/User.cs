using OrdersDomain.Core.Aggregates.Entities.Bases;
using System.ComponentModel.DataAnnotations;
using static OrdersDomain.Core.Enums.RoleEnums;

namespace OrdersDomain.Core.Aggregates.Entities.Users
{
    public class User : BaseEntity
    {
        public string AccountId { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Role RoleId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
