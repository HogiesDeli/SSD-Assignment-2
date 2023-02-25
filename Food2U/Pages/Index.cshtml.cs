using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Food2U.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Food2U.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly Food2UDbContext _context;

    public IndexModel(ILogger<IndexModel> logger, Food2UDbContext context)
    {
        _logger = logger;
        _context = context; //grab db context
    }

    //First dropdowns options
    public static IEnumerable<SelectListItem> userTypeOptions() {
        return new[]
        {
            new SelectListItem {Text = "Customer", Value = "Shoppers"},
            new SelectListItem {Text = "Delivery Driver", Value = "DeliverPerson"},
            new SelectListItem {Text = "Restaurant", Value = "LocalRestaurants"},
        };
    } 

    //list to stores db object queries
    public List<Shoppers> shopper {get; set;} = default!;
    public List<DeliveryPerson> deliveryPeople {get; set;} = default!;
    public List<LocalRestaurants> restaurants {get; set;} = default!;

    //select list to store the select list type chosen
    public SelectList? displayedDropDown {get; set;} = default!;

    //Temporary properties to binded to html to get values
    [BindProperty(SupportsGet = true)]
    public string? SelectedUserType {get; set;}

    [BindProperty(SupportsGet = true)]
    public int? SelectedUserID {get; set;}

    //Properties to remember selected temporary values - store selected in OnGet and OnPost method
    public string? UserType {get; set;}
    public int? UserID {get; set;}

    //called to select list (dropdown) of users depending on the first value selected
    public IActionResult OnGet()
        {
            //populate each dropdown type from db
            shopper = _context.Shoppers.ToList();
            deliveryPeople = _context.DeliveryPerson.ToList();
            restaurants = _context.LocalRestaurants.ToList();

            //save selected userid for when page changes
            if (SelectedUserType != null)
            {
                UserType = SelectedUserType;
            }

            //Switch statement to set dropdown users depending on selected type
            if (UserType != null) 
            {
                switch (UserType) //sort posts - date desc is defaulted
                {
                case "Shoppers":
                    displayedDropDown = new SelectList(shopper, "shoppersID", "Name");
                    break;
                case "DeliverPerson":
                    displayedDropDown = new SelectList(deliveryPeople, "deliverypersonID", "Name");
                    break;
                case "LocalRestaurants":
                    displayedDropDown =  new SelectList(restaurants, "localrestaurantsID", "Name");
                    break;
                default:
                    displayedDropDown = null;
                    break;

                }
            }

            return Page();
        }
    
    //Post values and reroute depending on selected values
    public IActionResult OnPost()
    {
        //store usertype if not null
        if (SelectedUserType != null)
        {
            UserType = SelectedUserType;
        }

        //log usertype to see whats passed
        _logger.LogWarning(UserType);

        //store userid if not null
        if (SelectedUserID != null)
            {
                UserID = SelectedUserID;
            }

        //log userid if not null
        _logger.LogWarning(UserID.ToString());

        //if usertype is shoppers and userid is populated then route to chooseitems.cshtml page and pass variables to use if needed
        if (UserType == "Shoppers" && UserID != null)
                {
                    return RedirectToPage("./Chooseitems", new {userId = UserID, userType = UserType});
                }
        
        if (UserType == "LocalRestaurants" && UserID != null)
                {
                    return RedirectToPage("./LocalRestaurant", new {userId = UserID, userType = UserType});
                }
        
        //return new Index page if routing criteria not met to start over
        return RedirectToPage("./Index");
    }
}
