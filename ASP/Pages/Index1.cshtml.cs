using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using RazorAuthDemo.Data;
using Microsoft.AspNetCore.Identity;

namespace RazorAuthDemo.Pages
{
    public class Index1Model : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public void OnGet() { }

        private readonly Database DBUsers;
        public Index1Model(Database UserDB)
        {
            DBUsers = UserDB;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = DBUsers.Users.FirstOrDefault(u => u.Name == Name && u.Password == Password);
            if (user != null)
            {
                var claims = new[] { new Claim(ClaimTypes.Name, Name) };
                var identity = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                IdentityConstants.ApplicationScheme, 
                principal
                );
                // skriven med hjälp av AI

                return RedirectToPage("/Main");
            }

            return Page();
        }
    }
}
