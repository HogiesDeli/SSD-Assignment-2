using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Food2U.Models;

namespace Food2U.Pages;

public class ChooseItemsModel : PageModel
{
    private readonly Food2UDbContext _context;
    private readonly ILogger<ChooseItemsModel> _logger;

    public ChooseItemsModel(Food2UDbContext context, ILogger<ChooseItemsModel> logger)
    {
        _logger = logger;
        _context = context;
    }

    public List<LocalRestaurants> LocalRestaurants { get; set; } = default!;
    public List<Items> Items { get; set; } = default!;

    public void OnGet(int? userId, string? userType)
    {

    }
}