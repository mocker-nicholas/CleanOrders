using CleanOrders.Application.Common.Dtos.Orders;
using MediatR;
using OrdersDomain.Core.Aggregates.Entities.Orders;

namespace CleanOrders.Application.Commands.Orders
{
    public class CreateOrderCommand : IRequest<CreateOrderResponse>
    {
        public string AccountId { get; set; }
        public decimal Total { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Address? BillToAddress { get; set; }
        public Address? ShipToAddress { get; set; }
        public Address? PayToAddress { get; set; }
        public ICollection<LineItem> LineItems { get; set; }
    }
}
