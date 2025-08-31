using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using RazorAuthDemo.Data;

namespace RazorAuthDemo.Pages
{
    [Authorize]
    public class MainModel : PageModel
    {

        private readonly Database Addproj;
        public MainModel(Database context)
        {
            Addproj = context;
        }
        public List<Project> Projects { get; set; } = new List<Project>();
        public void OnGet()
        {
            Projects = Addproj.Projects.ToList();
        }
    }
}
