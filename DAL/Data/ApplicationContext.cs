using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Compare> Compare { get; set; }
        public DbSet<RentTime> RentTime { get; set; }
		public DbSet<RentArchive> RentArchive { get; set; }
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; }
        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();   // creating database in first launch
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=rentcar.db;Trusted_Connection=True;");
        }
    }
}
