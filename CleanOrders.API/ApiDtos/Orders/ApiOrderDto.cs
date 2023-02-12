using OrdersDomain.Core.Aggregates.Entities.Orders;

namespace CleanOrders.API.ApiDtos.Orders
{
    public class ApiOrderDto
    {
        public string AccountId { get; set; }
        public decimal Total { get; set; }
        public DateTime DateCreated { get; set; }
        public Address BusinessAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public IList<LineItem> LineItems { get; set; }
    }
}