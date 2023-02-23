using Microsoft.EntityFrameworkCore;

namespace Food2U.Models
{
    public class Food2UDbContext : DbContext
    {
        public Food2UDbContext(DbContextOptions<Food2UDbContext> options) : base(options)
        { }

        public DbSet<Shoppers> Shoppers { get; set; } = default!;
        public DbSet<DeliveryPerson> DeliveryPerson { get; set; } = default!;
        public DbSet<LocalRestaurants> LocalRestaurants { get; set; } = default!;
        public DbSet<Items> Items { get; set; } = default!;
    }
}