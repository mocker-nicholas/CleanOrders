using Microsoft.EntityFrameworkCore;
using OrdersDomain.Core.Aggregates.Entities.Accounts;
using OrdersDomain.Core.Aggregates.Entities.Orders;
using OrdersDomain.Core.Aggregates.Entities.Users;
using OrdersDomain.Core.Interfaces;

namespace CleanOrders.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditable>())
            {
                entry.Entity.DateModified = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrderAddress>()
                .Property(address => address.Country)
                .HasConversion<string>();
            builder.Entity<OrderAddress>()
            .Property(address => address.State)
               .HasConversion<string>();
            builder.Entity<Permissions>().HasNoKey();
        }
        public DbSet<Account> Accounts { get; set; }
    }
}
