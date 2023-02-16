using CleanOrders.Application.Commands.Orders;
using OrdersDomain.Core.Aggregates.Entities.Orders;

namespace CleanOrders.Application.Common.Dtos.Orders
{
    public class OrderResponseDto
    {
        public OrderResponseDto(CreateOrderCommand command)
        {
            AccountId = command.AccountId;
            Total = command.Total;
            BillToAddress = command.BillToAddress;
            ShipToAddress = command.ShipToAddress;
            PayToAddress = command.PayToAddress;
            LineItems = command.LineItems;
        }

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
