using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//HK
using Microsoft.EntityFrameworkCore;
using Food2U.Models;

namespace Food2U.Pages;

public class LocalRestaurantModel : PageModel
{
    private readonly Food2UDbContext _context;
    private readonly ILogger<LocalRestaurantModel> _logger;

    //Store restuarants items
    public List<Items> Items { get; set; } = default!;

    //Store logged in restuarant information
    public LocalRestaurants? UserRestaurant {get; set;}



    public LocalRestaurantModel(Food2UDbContext context, ILogger<LocalRestaurantModel> logger)
    {
        _context = context;
        _logger = logger;

        
    }

    public void OnGet(int? userId, string? userType)
    {   
        //Grab logged in restaurant user information
        UserRestaurant = _context.LocalRestaurants.Where(u => u.localrestaurantsID == userId).FirstOrDefault();
        
        //Grab restaurants items where restaurantId equals logged in restaurant
        Items = _context.Items.Where(i => i.localrestaurantsID == userId).ToList();
    }
}
