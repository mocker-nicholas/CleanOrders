using OrdersDomain.Core.Aggregates.Entities.Bases;
using OrdersDomain.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersDomain.Core.Aggregates.Entities.Orders
{
    public class Order : BaseEntity, IDateCreateable, IAuditable
    {
        [ForeignKey("Account")]
        public string AccountId { get; set; }
        public decimal Total { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public virtual ICollection<OrderAddress> Addresses { get; set; } = new List<OrderAddress>();
        [Required]
        public ICollection<LineItem> LineItems { get; set; }
    }
}
