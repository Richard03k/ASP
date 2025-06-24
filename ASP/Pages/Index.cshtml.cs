using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAuthDemo.Data;

namespace RazorAuthDemo.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public void OnGet() { }

        private readonly AddUser UserAdd;
        public IndexModel(AddUser userAdd)
        {
            UserAdd = userAdd;
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("OnPost");
            if (UserAdd.Account(Name, Password))
            {
                Console.WriteLine("OnPost");
                // TODO: Sign in logic here
                return RedirectToPage("/Main");
            }
            return Page();
        }
    }
}
