using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorAuthDemo.Data;
using System.Security.Claims;

namespace RazorAuthDemo.Pages
{
    public class editModel : PageModel
    {
        private readonly Database Editpro;

        [BindProperty(SupportsGet = true)] //skriven med hjälp av AI
        public Guid Id { get; set; }

        [BindProperty]
        public Project Project { get; set; }
        public editModel(Database ProjAdd)
        {
            Editpro = ProjAdd;
        }
        public void OnGet()
        {
            Project = Editpro.Projects.FirstOrDefault(p => p.ProjectID == Id);
        }
        public IActionResult OnPost()
        {
            var project = Editpro.Projects.FirstOrDefault(p => p.ProjectID == Project.ProjectID);
            if (project != null)
            {
                project.ProjectName = Project.ProjectName;
                project.ClientName = Project.ClientName;
                project.Description = Project.Description;
                project.StartDate = Project.StartDate;
                project.EndDate = Project.EndDate;
                project.Budget = Project.Budget;
                project.State = Project.State;
                Editpro.SaveChanges();
                return RedirectToPage("/Main");
            }
            return Page();
        }
    }
}
