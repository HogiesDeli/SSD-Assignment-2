
using Microsoft.EntityFrameworkCore;


namespace Food2U.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Food2UDbContext(serviceProvider.GetRequiredService<DbContextOptions<Food2UDbContext>>()))
            {
                if (context.Shoppers.Any())
                {
                    return;
                }
                if (context.LocalRestaurants.Any())
                {
                    return;
                }
                if (context.DeliveryPerson.Any())
                {
                    return;
                }
                if (context.Items.Any())
                {
                    return;
                }


                context.Shoppers.AddRange(
                 new Shoppers { Name = "Hogan Karr", Address = "5555 Wolflin Drive" },
                 new Shoppers { Name = "John Hernandez", Address = "5556 Coulter Road" }
                );

                context.LocalRestaurants.AddRange(
                    new LocalRestaurants { Name = "Chick-fil-A", Address = "3420 Georgia Street" },
                    new LocalRestaurants { Name = "McDonald's", Address = "2600 34th Street" },
                    new LocalRestaurants { Name = "Burger King", Address = "6570 Washington Drive" },
                    new LocalRestaurants { Name = "Subway", Address = "839 Soncy Road" }
                );

                context.DeliveryPerson.AddRange(
                    new DeliveryPerson { Name = "Tom Hicks", Vehichle = "Ford Focus", Email = "tomhicks@gmail.com" },
                    new DeliveryPerson { Name = "Julie Bently", Vehichle = "Toyota Camery", Email = "jbently@outlook.com" }
                );

                context.Items.AddRange(
                    // Chick-fil-A items
                    new Items { Name = "12 Count Nugget Meal", Price = Convert.ToDecimal(10.55) },
                    new Items { Name = "Chick-fil-A Deluxe", Price = Convert.ToDecimal(9.25) },
                    new Items { Name = "Spicy Southwest Salad", Price = Convert.ToDecimal(9.69) },
                    new Items { Name = "Kids Nugget Meal", Price = Convert.ToDecimal(5.85) },
                    new Items { Name = "Vanilla Milkshake", Price = Convert.ToDecimal(4.45) },
                   // McDonald's Items
                   new Items { Name = "Big Mac Meal", Price = Convert.ToDecimal(11.04) },
                   new Items { Name = "Quarter Pounder with Cheese Meal", Price = Convert.ToDecimal(11.04) },
                   new Items { Name = "10 Piece McNuggets Meal", Price = Convert.ToDecimal(10.13) },
                   new Items { Name = "20 Piece McNuggets", Price = Convert.ToDecimal(9.09) },
                   new Items { Name = "3 Pack Of Cookies", Price = Convert.ToDecimal(1.69) },
                   //Burger King Items
                   new Items { Name = "Whopper", Price = Convert.ToDecimal(6.19) },
                   new Items { Name = "Double Whopper", Price = Convert.ToDecimal(8.69) },
                   new Items { Name = "Triple Whopper", Price = Convert.ToDecimal(11.19) },
                   new Items { Name = "8 Piece Chicken Nuggets", Price = Convert.ToDecimal(1.99) },
                   new Items { Name = "Soft Serve Cup", Price = Convert.ToDecimal(1.00) },
                   //Subway Items
                   new Items { Name = "Meatball Marinara", Price = Convert.ToDecimal(7.29) },
                   new Items { Name = "B.L.T", Price = Convert.ToDecimal(8.49) },
                   new Items { Name = "Pizza Sub Melt", Price = Convert.ToDecimal(7.49) },
                   new Items { Name = "Spicy Italian", Price = Convert.ToDecimal(6.49) },
                   new Items { Name = "Subway Melt", Price = Convert.ToDecimal(9.49) }
                );

                context.SaveChanges();
            }
        }
    }
}