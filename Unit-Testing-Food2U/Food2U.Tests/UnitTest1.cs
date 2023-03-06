using Food2U.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;


namespace Food2U.Tests;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
       using (var db = new Food2UDbContext(Utilities.Utilities.TestDbContextOptions()))
        {
            var newShopper = new Items{
                Name = "Cake",
                Price = Convert.ToDecimal(12.99),
                localrestaurantsID = 1
            };

            List<Items> seedItems = await db.Items.ToListAsync();
            var newItem = new Items{
                Name = "Cake",
                Price = Convert.ToDecimal(12.99),
                localrestaurantsID = 1
            };

            await db.Items.AddAsync(newItem);
            await db.SaveChangesAsync();

            List<Items> afterAddItems = await db.Items.ToListAsync();

            Assert.Equal(seedItems, afterAddItems);
        }
    }
}