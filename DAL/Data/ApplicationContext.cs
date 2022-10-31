using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureCreated();   // creating database in first launch
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=rentcar.db;Trusted_Connection=True;");
        }

    }
}
