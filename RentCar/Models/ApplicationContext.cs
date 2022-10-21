using Microsoft.EntityFrameworkCore;

namespace RentCar.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public ApplicationContext()
        {
            
            Database.EnsureCreated();   // creating database in first launch
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = rentcar.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasCheckConstraint("Age", "Age > 0 AND Age < 110");
        }

        
    }
}
