using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using RazorAuthDemo.Data;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult OnPost(Guid id)
        {
            var project = Addproj.Projects.FirstOrDefault(p => p.ProjectID == id);
            if (project != null)
            {
                Addproj.Projects.Remove(project);
                Addproj.SaveChanges();  
            }
            return RedirectToPage("/Main");
        }
    }
}
