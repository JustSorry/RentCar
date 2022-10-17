using Microsoft.EntityFrameworkCore;

namespace RentCar.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Car> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
