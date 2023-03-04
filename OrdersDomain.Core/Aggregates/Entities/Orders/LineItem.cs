using OrdersDomain.Core.Aggregates.Entities.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersDomain.Core.Aggregates.Entities.Orders
{
    public class LineItem : BaseEntity
    {
        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
