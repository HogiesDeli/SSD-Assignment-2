using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;

namespace Food2U.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var db = new Food2UContext(serviceProvider.GetRequiredService<DbContextOptions<Food2UContext>>()))
            {
                if( db.Shoppers.Any())
                {
                    return;
                }
                if( db.LocalRestaurants.Any())
                {
                    return;
                }
                if( db.DeliverPerson.Any())
                {
                    return;
                }
                if( db.Items.Any())
                {
                    return;
                }
                if( db.Order.Any())
                {
                    return;
                }

                db.Shoppers.AddRange(
                 new Shoppers { Name = "Hogan Karr", Address = "5555 Wolflin Drive" },
                 new Shoppers { Name = "John Hernandez", Address = "5556 Coulter Road"}   
                );

                db.LocalRestaurants.AddRange(
                    new LocalRestaurants { Name = "Chick-fil-A", Address = "3420 Georgia Street"},
                    new LocalRestaurants { Name = "McDonald's", Address = "2600 34th Street"},
                    new LocalRestaurants { Name = "Burger King", Address = "6570 Washington Drive"},
                    new LocalRestaurants { Name = "Subway", Address = "839 Soncy Road"}
                );

                db.DeliverPerson.AddRange(
                    new DeliveryPerson { Name = "Tom Hicks", Vehichle = "Ford Focus", Email = "tomhicks@gmail.com"},
                    new DeliveryPerson { Name = "Julie Bently", Vehichle = "Toyota Camery", Email = "jbently@outlook.com"}
                );

                db.Items.AddRange(
                    // Chick-fil-A items
                    new Items {Name = "12 Count Nugget Meal", Price = Convert.ToDecimal(10.55)},
                    new Items {Name = "Chick-fil-A Deluxe", Price = Convert.ToDecimal(9.25)},
                    new Items {Name = "Spicy Southwest Salad", Price = Convert.ToDecimal(9.69)},
                    new Items {Name = "Kids Nugget Meal", Price = Convert.ToDecimal(5.85)},
                    new Items {Name = "Vanilla Milkshake", Price = Convert.ToDecimal(4.45)}
                //     // McDonald's Items
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    //Burger King Items
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    //Subway Items
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    new Items {Name = "", Price = Convert.ToDecimal()},
                //    new Items {Name = "", Price = Convert.ToDecimal()}
                );

                db.Order.AddRange(

                );
            }
        }
    }
}