using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<RentTime> RentTime { get; set; }
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

        //    modelBuilder
        //        .Entity<Car>()
        //        .HasMany(c => c.Users)
        //        .WithMany(u => u.RentingCars)
        //        .UsingEntity<RentTime>(
        //            r => r
        //            .HasOne(pt => pt.User)
        //            .WithMany(t => t.RentTime)
        //            .HasForeignKey(pt => pt.UserId),
        //            r => r
        //            .HasOne(pt => pt.Car)
        //            .WithMany(t => t.RentTime)
        //            .HasForeignKey(pt => pt.CarId),
        //            r =>
        //            {
        //                r.Property(pt => pt.RentStartTime);
        //                r.Property(pt => pt.RentEndTime);
        //                r.HasKey(t => new { t.CarId, t.UserId });
        //                r.ToTable("CarUser");
        //            }) ;
        //}
    }
}
