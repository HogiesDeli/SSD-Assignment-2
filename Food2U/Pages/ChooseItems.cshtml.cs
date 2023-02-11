using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Food2U.Pages;

public class ChooseItemsModel : PageModel
{
    private readonly ILogger<ChooseItemsModel> _logger;

    public ChooseItemsModel(ILogger<ChooseItemsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}