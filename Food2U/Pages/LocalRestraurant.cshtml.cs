using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//HK
using Microsoft.EntityFrameworkCore;
using Food2U.Models;
using System.ComponentModel.DataAnnotations;

namespace Food2U.Pages;

public class LocalRestaurantModel : PageModel
{
    private readonly Food2UDbContext _context;
    private readonly ILogger<LocalRestaurantModel> _logger;

    //Store restuarants items
    public List<Items>? Items { get; set; } = default!;

    //Store logged in restuarant information when retrieving page
    public LocalRestaurants? UserRestaurant {get; set;}

    //Bound to form to grab new item properties
    [BindProperty]
    [Required]
    public Items item {get; set;} = default!;

    //Store userid/usertype and pass them during page reloads
    public int? UserId {get; set;}
    public string? UserType {get; set;}


    public LocalRestaurantModel(Food2UDbContext context, ILogger<LocalRestaurantModel> logger)
    {
        _context = context;
        _logger = logger;

    }

    //reload page with userid and type passed through routes
    public async Task<IActionResult> OnGet(int? userId, string? userType)
    {   
        //redirect if user "authentication" is not valid"
        if (userId == null || userType == null)
        {
            return RedirectToPage("./Index");
        }

        if (userType != null) //assign type if not null
        {
            UserType = userType;
        }
        
        if (userId != null)
        {
            UserId = userId; //assign id if not null
        }

        //grab restaurant information to show on page
        UserRestaurant = await _context.LocalRestaurants.Where(u => u.localrestaurantsID == UserId).FirstOrDefaultAsync();

        if (UserRestaurant == null)
        {
            return RedirectToPage("./Index");
        }
        
        //Grab restaurants items where restaurantId equals logged in restaurant
        Items = await _context.Items.Where(i => i.localrestaurantsID == UserId).ToListAsync();
        
        return Page();
    }

    //post with delete or addd new item functionality
    public async Task<IActionResult> OnPost(int? userId, string? userType, string? functionType, int? itemId){

        //Manage selected button functionality type to keep logic frrom mixing
        switch (functionType)
        {
            case "delete":
                //Find post selected to delete
                var itemToRemove = await _context.Items.FindAsync(itemId);

                //remove post
                _context.Items.Remove(itemToRemove!);

                //save changes
                _context.SaveChanges();

                break;
            case "addItem":
                //create new item
                item.Name = item!.Name;
                item.Price = Convert.ToDecimal(item.Price);
                item.localrestaurantsID = (int)userId!;

                //add item to db
                await _context.AddAsync(item);

                //save changes
                await _context.SaveChangesAsync();

                break;
        }

        

        //reload page and pass variables to act as a refresh
        return RedirectToPage("./LocalRestaurant", new {userId = userId, userType = userType});
    }
}
