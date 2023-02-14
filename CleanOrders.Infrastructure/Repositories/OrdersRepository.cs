using CleanOrders.Application.Interfaces.Repositories;
using OrdersDomain.Core.Aggregates.Entities.Orders;

namespace CleanOrders.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepositoryAsync
    {
        public Task<Order> AddAsync(Order user)
        {
            throw new NotImplementedException();
        }
    }
}
