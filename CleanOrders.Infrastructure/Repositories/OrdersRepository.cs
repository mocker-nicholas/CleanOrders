using CleanOrders.Application.Interfaces.Repositories;
using CleanOrders.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using OrdersDomain.Core.Aggregates.Entities.Orders;

namespace CleanOrders.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepositoryAsync
    {
        private readonly ApplicationContext _context;
        public OrdersRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Order> AddAsync(Order order, List<Address> addresses, List<LineItem> items)
        {
            await _context.Orders.AddAsync(order);

            if (items.Count > 0)
                await _context.LineItems.AddRangeAsync(items);

            if (addresses.Count > 0)
                await _context.Address.AddRangeAsync(addresses);

            await _context.SaveChangesAsync();
            return await _context.Orders.FirstOrDefaultAsync((x => x.Id == order.Id));
        }
    }
}
