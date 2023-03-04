using Microsoft.EntityFrameworkCore;
using OrdersDomain.Core.Aggregates.Entities.Accounts;
using OrdersDomain.Core.Aggregates.Entities.Orders;
using OrdersDomain.Core.Aggregates.Entities.Users;

namespace CleanOrders.Infrastructure.Data
{
    public interface IHalfApplicationContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<BusinessAddress> BusinessAddresses { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
    }

    public interface IOtherHalfApplicationContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
    }
}
