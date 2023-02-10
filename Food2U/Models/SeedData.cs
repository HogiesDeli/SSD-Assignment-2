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

                );

                db.LocalRestaurants.AddRange(

                );

                db.DeliverPerson.AddRange(

                );

                db.Items.AddRange(

                );

                db.Order.AddRange(

                );
            }
        }
    }
}