using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Food2U.Pages;

public class LocalRestaurantModel : PageModel
{
    private readonly ILogger<LocalRestaurantModel> _logger;

    public LocalRestaurantModel(ILogger<LocalRestaurantModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
