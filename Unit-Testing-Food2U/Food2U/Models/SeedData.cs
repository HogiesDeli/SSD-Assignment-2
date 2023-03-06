using Microsoft.EntityFrameworkCore;


namespace Food2U.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Food2UDbContext(serviceProvider.GetRequiredService<DbContextOptions<Food2UDbContext>>()))
            {
                //Checks for Shoppers changes in DB and adds changes
                if (context.Shoppers.Any())
                {
                    return;
                }

                var karr = new Shoppers
                {
                    Name = "Hogan Karr",
                    Address = "39 Green Street"
                };
                var hernandez = new Shoppers
                {
                    Name = "John Hernandez",
                    Address = "763 Shady St."
                };
                var defore = new Shoppers
                {
                    Name = "John DeFore",
                    Address = "7 Columbia Ave."
                };
                var alatorre = new Shoppers
                {
                    Name = "Andrew Alatorre",
                    Address = "9473 NE. Oxford Drive"
                };

                var shoppers = new Shoppers[]
                {
                    karr,
                    hernandez,
                    defore,
                    alatorre
                };
                context.AddRange(shoppers);

                //Checks for DeliveryPerson changes in DB and adds changes
                if (context.DeliveryPerson.Any())
                {
                    return;
                }

                var hicks = new DeliveryPerson
                {
                    Name = "Tom Hicks",
                    Vehicle = "Ford Focus",
                    Email = "tomhicks@gmail.com"
                };
                var bently = new DeliveryPerson
                {
                    Name = "Julie Bently",
                    Vehicle = "Toyota Camery",
                    Email = "jbently@outlook.com"
                };

                var deliveryperson = new DeliveryPerson[]
                {
                    hicks,
                    bently
                };
                context.AddRange(deliveryperson);

                //Checks for LocalRestaurants changes in DB and adds changes
                if (context.LocalRestaurants.Any())
                {
                    return;
                }

                var chickfila = new LocalRestaurants
                {
                    Name = "Chick-fil-A",
                    Address = "2 Thompson Street"
                };
                var mcdonalds = new LocalRestaurants
                {
                    Name = "McDonald's",
                    Address = "453 Edgewater St."
                };
                var burgerking = new LocalRestaurants
                {
                    Name = "Burger King",
                    Address = "9003 Walt Whitman Dr."
                };
                var subway = new LocalRestaurants
                {
                    Name = "Subway",
                    Address = "52 Summit Ave."
                };

                var localrestaurants = new LocalRestaurants[]
                {
                    chickfila,
                    mcdonalds,
                    burgerking,
                    subway
                };
                context.AddRange(localrestaurants);


                if (context.Items.Any())
                {
                    return;
                }

                var twelvenugmeal = new Items
                {
                    Name = "12 Count Nugget Meal",
                    Price = 10.55M,
                    LocalRestaurants = chickfila
                };
                var CFAdeluxe = new Items
                {
                    Name = "Chick-fil-A Deluxe",
                    Price = 9.25M,
                    LocalRestaurants = chickfila
                };
                var southwestsalad = new Items
                {
                    Name = "Spicy Southwest Salad",
                    Price = 9.69M,
                    LocalRestaurants = chickfila
                };
                var kidnugmeal = new Items
                {
                    Name = "Kids Nugget Meal",
                    Price = 5.85M,
                    LocalRestaurants = chickfila
                };
                var vanillaMilkshake = new Items
                {
                    Name = "Vanilla Milkshake",
                    Price = 4.45M,
                    LocalRestaurants = chickfila
                };
                var bigmacmeal = new Items
                {
                    Name = "Big Mac Meal",
                    Price = 11.04M,
                    LocalRestaurants = mcdonalds
                };
                var quarterpounder = new Items
                {
                    Name = "Quarter Pounder with Cheese Meal",
                    Price = 11.04M,
                    LocalRestaurants = mcdonalds
                };
                var tennugmeal = new Items
                {
                    Name = "10 Piece McNuggets Meal",
                    Price = 10.13M,
                    LocalRestaurants = mcdonalds
                };
                var twentynuggets = new Items
                {
                    Name = "20 Piece McNuggets",
                    Price = 9.09M,
                    LocalRestaurants = mcdonalds
                };
                var threecookies = new Items
                {
                    Name = "3 Pack Of Cookies",
                    Price = 1.69M,
                    LocalRestaurants = mcdonalds
                };
                var whopper = new Items
                {
                    Name = "Whopper",
                    Price = 6.19M,
                    LocalRestaurants = burgerking
                };
                var doublewhopper = new Items
                {
                    Name = "Double Whopper",
                    Price = 8.69M,
                    LocalRestaurants = burgerking
                };
                var triplewhopper = new Items
                {
                    Name = "Triple Whopper",
                    Price = 11.19M,
                    LocalRestaurants = burgerking
                };
                var eightnuggets = new Items
                {
                    Name = "8 Piece Chicken Nuggets",
                    Price = 1.99M,
                    LocalRestaurants = burgerking
                };
                var softservecup = new Items
                {
                    Name = "Soft Serve Cup",
                    Price = 1.00M,
                    LocalRestaurants = burgerking
                };
                var meatballmari = new Items
                {
                    Name = "Meatball Marinara",
                    Price = 7.29M,
                    LocalRestaurants = subway
                };
                var BLT = new Items
                {
                    Name = "B.L.T",
                    Price = 8.49M,
                    LocalRestaurants = subway
                };
                var pizzasub = new Items
                {
                    Name = "Pizza Sub Melt",
                    Price = 7.49M,
                    LocalRestaurants = subway
                };
                var spicyitalian = new Items
                {
                    Name = "Spicy Italian",
                    Price = 6.49M,
                    LocalRestaurants = subway
                };
                var subwaymelt = new Items
                {
                    Name = "Subway Melt",
                    Price = 9.49M,
                    LocalRestaurants = subway
                };

                var items = new Items[]
                {
                    twelvenugmeal,
                    CFAdeluxe,
                    southwestsalad,
                    kidnugmeal,
                    vanillaMilkshake,
                    bigmacmeal,
                    quarterpounder,
                    tennugmeal,
                    twentynuggets,
                    threecookies,
                    whopper,
                    doublewhopper,
                    triplewhopper,
                    eightnuggets,
                    softservecup,
                    meatballmari,
                    BLT,
                    pizzasub,
                    spicyitalian,
                    subwaymelt
                };
                context.AddRange(items);

                context.SaveChanges();
            }
        }
    }
}