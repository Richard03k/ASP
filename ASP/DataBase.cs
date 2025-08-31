using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RazorAuthDemo.Data
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
    }


    public class AddUser
    {
        private readonly Database context;

        public AddUser(Database textcon)
        {
            context = textcon;
        }
        public bool Account(string name, string password)
        {
            var user = new User {Name = name, Password = password };
            context.Users.Add(user);
            return context.SaveChanges() > 0;            
        }
    }

    public class Project
    {
        [Key]
        public Guid ProjectID { get; set; } = Guid.NewGuid();
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Budget { get; set; }
    }

    public class AddProject
    {
        private readonly Database context;
        public AddProject(Database textcon)
        {
            context = textcon;
        }
        public bool Projekt(string projectname, string clientname, string description, string startdate, string enddate, string budget)
        {
            var proj = new Project 
            { 
                ProjectName = projectname, 
                ClientName = clientname,
                Description = description, 
                StartDate = startdate, 
                EndDate = enddate, 
                Budget = budget 
            };
            context.Projects.Add(proj);
            return context.SaveChanges() > 0;
        }
    }
}
