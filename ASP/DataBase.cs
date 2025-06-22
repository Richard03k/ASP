using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RazorAuthDemo.Data
{
    // Entity class
    public class User
    {
        [Key]
        public Guid UserID { get; set; } = Guid.NewGuid(); // EF Core requires a primary key
        public string Name { get; set; }
        public string Password { get; set; }
    }

    // DbContext class
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }

    // Service for user operations
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
            Console.WriteLine("worked");
            return context.SaveChanges() > 0;            
        }
    }
}
