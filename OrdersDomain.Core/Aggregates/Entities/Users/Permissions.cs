using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersDomain.Core.Aggregates.Entities.Users
{
    public class Permissions
    {
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public bool CreateUsers { get; set; } = true;
        public bool UpdateUsers { get; set; } = true;
        public bool CreateOrders { get; set; } = true;
        public bool UpdateOrders { get; set; } = true;
    }
}
