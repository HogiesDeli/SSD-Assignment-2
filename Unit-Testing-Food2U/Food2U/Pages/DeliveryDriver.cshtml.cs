using System.Diagnostics;
using Food2U.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Food2U.Pages;

public class DeliveryDriver : PageModel
{
    private readonly ILogger<ErrorModel> _logger;
    private readonly Food2UDbContext? _context;

    public DeliveryDriver(ILogger<ErrorModel> logger, Food2UDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    //Store driver info on load
    public DeliveryPerson? Driver {get; set;}

    public async Task<IActionResult> OnGet(int? userId, string? usertype)
    {
        //Act as a auth method to redirect to login if not passed check
        if (userId == null || usertype != "DeliverPerson")
        {
            return RedirectToPage("./Index");
        }

        //grab driver info
        Driver = await _context.DeliveryPerson.Where(i => i.deliverypersonID == (int)userId).FirstOrDefaultAsync();


        //Load this page
        return Page();
    }
}