using OrdersDomain.Core.Aggregates.Entities.Orders;

namespace CleanOrders.API.ApiDtos.Orders
{
    public class CreateOrderDto
    {
        public string AccountId { get; set; }
        public decimal Total { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string? BillToId { get; set; }
        public string? ShipToId { get; set; }
        public string? PayToId { get; set; }
        public Address? BillToAddress { get; set; }
        public Address? ShipToAddress { get; set; }
        public Address? PayToAddress { get; set; }
        public ICollection<LineItem> LineItems { get; set; }
    }
}