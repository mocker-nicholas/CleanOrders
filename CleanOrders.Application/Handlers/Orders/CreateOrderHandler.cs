using CleanOrders.Application.Commands.Orders;
using CleanOrders.Application.Common.Dtos.Orders;
using CleanOrders.Application.Interfaces.Repositories;
using MediatR;

namespace CleanOrders.Application.Handlers.Orders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IOrdersRepositoryAsync _ordersRepository;

        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new OrderResponseDto(request);
            return new CreateOrderResponse(response);
        }
    }
}
