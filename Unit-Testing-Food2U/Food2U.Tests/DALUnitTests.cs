using Food2U.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;


namespace Food2U.Tests;

public class UnitTest1
{
    //Test that adding item to db works when data is correct
    //Can be found in LocalRestaurant.cshtml.cs
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

    //Test that exception gets thrown if incorrect data gets entered when adding an item
    //Can be Found in LocalRestaurant.cshtml.cs of Food2U
    [Fact] 
    public void RestaurantAddItemAsync_ItemNotAddedShouldThrowException_WhenDataIsNotCorrect()
    {
        Assert.Throws<FormatException>(() => new Items
        {
            Name = "Cake",
            Price = Convert.ToDecimal("abc"),
            localrestaurantsID = 1
        });

    }

    //Test that list still gets returned even if no Items are found
    //Tests the method that creates lists for the dictionary found in ChooseItems.cshtml.cs
    [Fact]
    public async Task getRestaurantItemsAsync_DoesNotThrowException_WhenItemsAreEmpty()
    {
        using (var db = new Food2UDbContext(Utilities.Utilities.TestDbContextOptions()))
        {
            int restaurantID = 1;

            List<Items> foodItems = await db.Items.Where(i => i.localrestaurantsID == restaurantID).ToListAsync();

            Assert.Empty(foodItems);
        }
    }
}