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
    public List<LocalRestaurants> LocalRestaurants { get; set; } = default!;

    public LocalRestaurantModel(Food2UDbContext context, ILogger<LocalRestaurantModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
        LocalRestaurants = _context.LocalRestaurants.ToList();
    }
}
