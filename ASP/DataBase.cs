using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RazorAuthDemo.Data
{
    public class DataBase : IdentityDbContext
    {
        public DataBase(DbContextOptions<DataBase> options)
            : base(options) { }
    }
}