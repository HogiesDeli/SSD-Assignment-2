using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Food2U.Models;
using Microsoft.EntityFrameworkCore;

namespace Food2U.Pages;

public class ChooseItemsModel : PageModel
{
    private readonly Food2UDbContext _context;
    private readonly ILogger<ChooseItemsModel> _logger;

    public Shoppers? shopper {get; set;}

    [BindProperty]
    public Items? Item {get; set;}

    public Dictionary<LocalRestaurants, List<Items>> restaurantMenus {get; set;} = new Dictionary<LocalRestaurants, List<Items>>();

    public ChooseItemsModel(Food2UDbContext context, ILogger<ChooseItemsModel> logger)
    {
        _logger = logger;
        _context = context;
    }

    public List<LocalRestaurants> LocalRestaurants { get; set; } = default!;

    public async Task<IActionResult> OnGet(int? userId, string? userType, string? functionType, int? itemid)
    {

        shopper = await _context.Shoppers.Where(u => u.shoppersID == (int)userId!).FirstOrDefaultAsync();

        var restaurantsList = await _context.LocalRestaurants.ToListAsync();

        foreach (LocalRestaurants restaurant in restaurantsList)
        {
            restaurantMenus.Add(restaurant, _getRestaurantItemsAsync(restaurant.localrestaurantsID).Result);
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
                _logger.LogWarning(getItem.Name);

                break;
        }

        return RedirectToPage("./ChooseItems", new {userId = userId, userType = userType});
    }
    
    private async Task<List<Items>> _getRestaurantItemsAsync(int restaurantID)
    {
        List<Items> foodItems = await _context.Items.Where(i => i.localrestaurantsID == restaurantID).ToListAsync();

        return foodItems;
    }
}