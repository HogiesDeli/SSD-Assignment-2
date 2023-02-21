using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//HK
using Microsoft.EntityFrameworkCore;
using Food2U.Models;

namespace Food2U.Pages;

public class IndexModel : PageModel
{
    private readonly Food2UDbContext _context;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(Food2UDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {

    }
}