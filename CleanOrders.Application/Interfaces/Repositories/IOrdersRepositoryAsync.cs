using OrdersDomain.Core.Aggregates.Entities.Orders;

namespace CleanOrders.Application.Interfaces.Repositories
{
    public interface IOrdersRepositoryAsync
    {
        Task<Order> AddAsync(Order order, List<Address> addresses, List<LineItem> items);
    }
}
