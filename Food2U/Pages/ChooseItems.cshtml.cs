using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Food2U.Models;
using Microsoft.EntityFrameworkCore;

namespace Food2U.Pages;

public class ChooseItemsModel : PageModel
{
    private readonly Food2UDbContext _context;
    private readonly ILogger<ChooseItemsModel> _logger;

    public Shoppers? Shopper { get; set; }

    [BindProperty]
    public Items? Item { get; set; }

    public Dictionary<LocalRestaurants, List<Items>> RestaurantMenus { get; set; } = new Dictionary<LocalRestaurants, List<Items>>();

    public List<Items> ShoppingCart { get; set; } = new List<Items>();

    public ChooseItemsModel(Food2UDbContext context, ILogger<ChooseItemsModel> logger)
    {
        _logger = logger;
        _context = context;
    }

    public List<LocalRestaurants> LocalRestaurants { get; set; } = default!;

    public async Task<IActionResult> OnGet(int? userId, string? userType, string? objectStringfied)
    {
        if (objectStringfied != null)
        {
            _logger.LogWarning(objectStringfied);
            ShoppingCart = TempData["cart"] as List<Items>;
            foreach (var item in ShoppingCart)
            {
                _logger.LogWarning(item.Name);
            }
        }

        Shopper = await _context.Shoppers.Where(u => u.shoppersID == (int)userId!).FirstOrDefaultAsync();

        var restaurantsList = await _context.LocalRestaurants.ToListAsync();

        foreach (LocalRestaurants restaurant in restaurantsList)
        {
            RestaurantMenus.Add(restaurant, _getRestaurantItemsAsync(restaurant.localrestaurantsID).Result);
        }

        return Page();
    }

    public async Task<IActionResult> OnPost(int? userId, string? userType, string? functionType, int? itemid, int? restaurantId)
    {
        _logger.LogWarning(functionType);
        _logger.LogWarning(itemid.ToString());
        switch (functionType)
        {
            case "addToCart":
                var getItem = await _context.Items.Where(r => r.localrestaurantsID == restaurantId).Where(i => i.itemsID == itemid).FirstOrDefaultAsync();
                ShoppingCart.Add(getItem);

                TempData["cart"] = ShoppingCart;

                foreach (var item in ShoppingCart)
                {
                    _logger.LogWarning("posting");
                    _logger.LogWarning(item.Name);
                }
                break;
        }

        return RedirectToPage("./ChooseItems", new { userId = userId, userType = userType, objectStringfied = Newtonsoft.Json.JsonConvert.SerializeObject(ShoppingCart) });
    }

    private async Task<List<Items>> _getRestaurantItemsAsync(int restaurantID)
    {
        List<Items> foodItems = await _context.Items.Where(i => i.localrestaurantsID == restaurantID).ToListAsync();

        return foodItems;
    }
}