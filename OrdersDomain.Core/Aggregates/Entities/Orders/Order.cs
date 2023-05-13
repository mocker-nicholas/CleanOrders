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
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateModified { get; set; } = DateTime.Now;

        [ForeignKey("BillToAddress")]
        public string? BillToId { get; set; }
        [ForeignKey("ShipToAddress")]
        public string? ShipToId { get; set; }
        [ForeignKey("PayToAddress")]
        public string? PayToId { get; set; }
        public Address? BillToAddress { get; set; }
        public Address? ShipToAddress { get; set; }
        public Address? PayToAddress { get; set; }
        [Required]
        public ICollection<LineItem> LineItems { get; set; }
    }
}
