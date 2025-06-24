using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace RazorAuthDemo.Pages
{
    [Authorize]
    public class MainModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
