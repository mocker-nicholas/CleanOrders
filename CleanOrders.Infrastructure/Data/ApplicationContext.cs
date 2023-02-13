using Microsoft.EntityFrameworkCore;
using OrdersDomain.Core.Aggregates.Entities.Accounts;
using OrdersDomain.Core.Aggregates.Entities.Orders;
using OrdersDomain.Core.Aggregates.Entities.Users;
using OrdersDomain.Core.Interfaces;
using static OrdersDomain.Core.Enums.AddressEnums;

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

            builder.Entity<Account>()
                .Property(x => x.Country)
                .HasConversion(x => x.ToString(), x => (Country)Enum.Parse(typeof(Country), x));
            builder.Entity<Account>()
                .Property(x => x.State)
                .HasConversion(x => x.ToString(), x => (State)Enum.Parse(typeof(State), x));
            builder.Entity<Address>()
            .Property(address => address.Country)
               .HasConversion<string>();
            builder.Entity<Address>()
            .Property(address => address.State)
               .HasConversion<string>();
            builder.Entity<User>()
            .Property(user => user.RoleId)
                .HasConversion<string>();
            builder.Entity<Permissions>().HasNoKey();

            // Creates a join table for addresses and account
            builder.Entity<Account>().HasMany(x => x.Addresses).WithOne();
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<BusinessAddress> BusinessAddresses { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
    }
}
