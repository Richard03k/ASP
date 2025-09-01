using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAuthDemo.Data;
using System.Security.Claims;

namespace RazorAuthDemo.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Project_Name { get; set; }
        [BindProperty]
        public string Project_Client { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string StartDate { get; set; }
        [BindProperty]
        public string EndDate { get; set; }
        [BindProperty]
        public string Budget { get; set; }
        [BindProperty]
        public string State { get; set; }

        private readonly AddProject ProjectAdd;
        public CreateModel(AddProject ProjAdd)
        {
            ProjectAdd = ProjAdd;
        }
        public IActionResult OnPost()
        {
            var user = ProjectAdd.Projekt(Project_Name, Project_Client, Description, StartDate, EndDate, Budget, State);

            return RedirectToPage("/Main");
        }
    }
}
