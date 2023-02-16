using CleanOrders.Application.Commands.Orders;
using CleanOrders.Application.Common.Dtos.Orders;
using CleanOrders.Application.Interfaces;
using CleanOrders.Application.Interfaces.Repositories;
using MediatR;
using OrdersDomain.Core.Aggregates.Entities.Orders;

namespace CleanOrders.Application.Handlers.Orders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IOrdersRepositoryAsync _ordersRepository;
        private readonly IUserService _userService;

        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Create an order
            Order newOrder = new();
            newOrder.AccountId = request.AccountId;
            newOrder.Total = request.Total;

            // Create Addresses
            List<Address> addresses = new();
            if (request.BillToAddress != null || request.ShipToAddress != null || request.PayToAddress != null)
            {
                if (request.BillToAddress != null)
                {
                    Address billTo = new();
                    billTo.FirstName = request.BillToAddress.FirstName;
                    billTo.LastName = request.BillToAddress.LastName;
                    billTo.StreetAddress1 = request.BillToAddress.StreetAddress1;
                    billTo.StreetAddress2 = request.BillToAddress.StreetAddress2;
                    billTo.Country = request.BillToAddress.Country;
                    billTo.State = request.BillToAddress.State;
                    billTo.PostalCode = request.BillToAddress.PostalCode;
                    newOrder.BillToId = billTo.Id;
                }
                if (request.ShipToAddress != null)
                {
                    Address shipTo = new();
                    shipTo.FirstName = request.ShipToAddress.FirstName;
                    shipTo.LastName = request.ShipToAddress.LastName;
                    shipTo.StreetAddress1 = request.ShipToAddress.StreetAddress1;
                    shipTo.StreetAddress2 = request.ShipToAddress.StreetAddress2;
                    shipTo.Country = request.ShipToAddress.Country;
                    shipTo.State = request.ShipToAddress.State;
                    shipTo.PostalCode = request.ShipToAddress.PostalCode;
                    newOrder.BillToId = shipTo.Id;
                }
                if (request.PayToAddress != null)
                {
                    Address payTo = new();
                    payTo.FirstName = request.PayToAddress.FirstName;
                    payTo.LastName = request.PayToAddress.LastName;
                    payTo.StreetAddress1 = request.PayToAddress.StreetAddress1;
                    payTo.StreetAddress2 = request.PayToAddress.StreetAddress2;
                    payTo.Country = request.PayToAddress.Country;
                    payTo.State = request.PayToAddress.State;
                    payTo.PostalCode = request.PayToAddress.PostalCode;
                    newOrder.BillToId = payTo.Id;
                }
            }

            List<LineItem> lineItems = new();

            var response = await _ordersRepository.AddAsync(newOrder, addresses, lineItems);
            return new CreateOrderResponse(response);
        }
    }
}
