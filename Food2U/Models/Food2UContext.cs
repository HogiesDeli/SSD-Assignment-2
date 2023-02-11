using Microsoft.EntityFrameworkCore;

namespace Food2U.Models
{
    public class Food2UContext : DbContext
    {
        public Food2UContext(DbContextOptions<Food2UContext> options)
        : base(options) 
        { 
            
        }

        public DbSet<Shoppers> Shoppers {get; set;} = default!;
        public DbSet<DeliveryPerson> DeliverPerson {get; set;} = default!;
        public DbSet<LocalRestaurants> LocalRestaurants {get; set;} = default!;
        public DbSet<Items> Items {get; set;} = default!;
        public DbSet<Order> Order {get; set;} = default!;
    }
}