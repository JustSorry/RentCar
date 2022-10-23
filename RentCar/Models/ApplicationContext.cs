using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RentCar.Models
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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasCheckConstraint("Age", "Age > 17 AND Age < 100");
        //}
    }
}
