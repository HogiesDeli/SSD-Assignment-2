using Food2U.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;


namespace Food2U.Tests;

public class UnitTest1
{
    [Fact]
    public async Task RestaurantAddItemAsync_ItemIsAdded_WhenDataIsCorrect()
    {
        using (var db = new Food2UDbContext(Utilities.Utilities.TestDbContextOptions()))
        {
            // Arrange 
            int expectedResult = 1;

            // Act
            var newItem = new Items
            {
                Name = "Cake",
                Price = Convert.ToDecimal(12.99),
                localrestaurantsID = 1
            };

            await db.Items.AddAsync(newItem);
            await db.SaveChangesAsync();

            List<Items> actualResultList = await db.Items.ToListAsync();

            // Assert
            Assert.Equal(expectedResult, actualResultList.Count);
        }
    }

    [Fact]
    public void RestaurantAddItemAsync_ItemNotAddedShouldThrowException_WhenDataIsNotCorrect()
    {
        
        using (var db = new Food2UDbContext(Utilities.Utilities.TestDbContextOptions()))
        {
            Assert.Throws<FormatException>(() =>  new Items
            {
                Name = "Cake",
                Price = Convert.ToDecimal("abc"),
                localrestaurantsID = 1
            });
        }
    }
}