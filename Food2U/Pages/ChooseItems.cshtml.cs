using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//HK
using Microsoft.EntityFrameworkCore;
using Food2U.Models;

namespace Food2U.Pages;

public class ChooseItemsModel : PageModel
{
    private readonly Food2UDbContext _context;
    private readonly ILogger<ChooseItemsModel> _logger;
    public List<Items> Items {get; set;} = default!;

    public ChooseItemsModel(Food2UDbContext context, ILogger<ChooseItemsModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
        Items = _context.Items.ToList();
    }
}