using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Food2U.Models;
using Microsoft.EntityFrameworkCore;

namespace Food2U.Pages;

public class ChooseItemsModel : PageModel
{
    private readonly Food2UDbContext _context;
    private readonly ILogger<ChooseItemsModel> _logger;

    //Store customer informtion
    public Shoppers? Shopper { get; set; }

    //grab entered item details
    [BindProperty]
    public Items? Item { get; set; }

    //Stores restaurants and its items for ease of access.
    public Dictionary<LocalRestaurants, List<Items>> RestaurantMenus { get; set; } = new Dictionary<LocalRestaurants, List<Items>>();


    public ChooseItemsModel(Food2UDbContext context, ILogger<ChooseItemsModel> logger)
    {
        _logger = logger;
        _context = context;
    }

    public List<LocalRestaurants> LocalRestaurants { get; set; } = default!;

    public async Task<IActionResult> OnGet(int? userId, string? userType)
    {
        _logger.LogWarning(userId.ToString());
        _logger.LogWarning(userType);
        //Acts as auth method to redirect to login if missing info
        if (userId == null || userType != "Shoppers")
        {
            return RedirectToPage("./Index");
        }

        //Grab shopper info
        Shopper = await _context.Shoppers.Where(u => u.shoppersID == (int)userId!).FirstOrDefaultAsync();

        //grab restaurant list
        var restaurantsList = await _context.LocalRestaurants.ToListAsync();

        //loop through list and add restaurant as key and its items as value to create menus
        foreach (LocalRestaurants restaurant in restaurantsList)
        {
            RestaurantMenus.Add(restaurant, _getRestaurantItemsAsync(restaurant.localrestaurantsID).Result);
        }

        //load this page
        return Page();
    }

    public IActionResult OnPost(int? userId, string? userType, string? functionType, int? itemid, int? restaurantId)
    {
        //Would hold logic if adding items to cart/removing
        switch (functionType)
        {
            case "addToCart":
                //cart functions would go here
                break;
            case "checkout":
                return RedirectToPage("./ShoppingCart", new { userId = userId, userType = userType });
        }

        //reload page
        return RedirectToPage("./ChooseItems", new { userId = userId, userType = userType });
    }

    //Loops through items to create list for Dictionary values in onGet
    private async Task<List<Items>> _getRestaurantItemsAsync(int restaurantID)
    {
        List<Items> foodItems = await _context.Items.Where(i => i.localrestaurantsID == restaurantID).ToListAsync();

        return foodItems;
    }
}