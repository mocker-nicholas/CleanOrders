using OrdersDomain.Core.Aggregates.Entities.Orders;

namespace CleanOrders.Application.Common.Dtos.Orders
{
    public class OrderResponseDto
    {
        public string AccountId { get; set; }
        public decimal Total { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
        public Address? BillToAddress { get; set; }
        public Address? ShipToAddress { get; set; }
        public Address? PayToAddress { get; set; }
        public ICollection<LineItem> LineItems { get; set; }
    }
}
