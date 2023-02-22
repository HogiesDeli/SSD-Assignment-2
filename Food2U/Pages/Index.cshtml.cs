using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Food2U.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Food2U.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly Food2UContext _context;
    public static IEnumerable<SelectListItem> userTypeOptions() {
        return new[]
        {
            new SelectListItem {Text = "Customer", Value = "Shoppers"},
            new SelectListItem {Text = "Delivery Driver", Value = "DeliverPerson"},
            new SelectListItem {Text = "Restaurant", Value = "LocalRestaurants"},
        };
    } 

    public List<Shoppers> shopper {get; set;} = default!;
    public List<DeliveryPerson> deliveryPeople {get; set;} = default!;
    public List<LocalRestaurants> restaurants {get; set;} = default!;

    public SelectList shopperList {get; set;} = default!;
    public SelectList deliveryDriverList {get; set;} = default!;
    public SelectList restaurantList {get; set;} = default!;

    public SelectList displayedDropDown {get; set;} = default!;

    public IActionResult OnGetFetchUserNames(string userType)
    {
        switch (userType)
        {
            case "Shoppers":
                displayedDropDown = shopperList;
                break;
            case "DeliverPerson":
                displayedDropDown = deliveryDriverList;
                break;
            case "LocalRestaurants":
                displayedDropDown = restaurantList;
                break;
        }

        Console.WriteLine(displayedDropDown.ToString());

        return new JsonResult(displayedDropDown);
    }

    public IndexModel(ILogger<IndexModel> logger, Food2UContext context)
    {
        _logger = logger;
        _context = context;
    }

    public void OnGet()
    {
        shopper = _context.Shoppers.ToList();
        deliveryPeople = _context.DeliverPerson.ToList();
        restaurants = _context.LocalRestaurants.ToList();

        shopperList = new SelectList(shopper, "shopperID", "Name");
        deliveryDriverList = new SelectList(deliveryPeople, "driverID", "Name");
        restaurantList = new SelectList(restaurants, "restaurantID", "Name");
    }
}
