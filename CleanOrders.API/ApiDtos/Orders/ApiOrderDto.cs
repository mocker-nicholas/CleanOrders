using OrdersDomain.Core.Aggregates.Entities.Orders;

namespace CleanOrders.API.ApiDtos.Orders
{
    public class ApiOrderDto
    {
        public string AccountId { get; set; }
        public decimal Total { get; set; }
        public DateTime DateCreated { get; set; }
        public OrderAddress BusinessAddress { get; set; }
        public OrderAddress ShippingAddress { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
}
