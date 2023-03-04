#region

using Microsoft.AspNetCore.Mvc.RazorPages;

#endregion

namespace RobertHeijn_Web_App.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;


    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}