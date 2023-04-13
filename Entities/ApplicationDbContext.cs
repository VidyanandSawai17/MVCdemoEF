using Microsoft.EntityFrameworkCore;
using MVCdemoEF.Models;

namespace MVCdemoEF.Entities

{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option):base(option)
        {

        }

        public DbSet<Product> Products { get; set; }

        //public DbSet<Employee> Employees { get; set; }

        //public DbSet<Student> Students { get; set; }
    }
}
