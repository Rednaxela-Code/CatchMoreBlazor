using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Catch> Catches { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>().HasData(new Session { Id = 1, Date = DateTime.Now, SessionName = "Test Session 1", Latitude = 12, Longitude = 22 });
            modelBuilder.Entity<Session>().HasData(new Session { Id = 2, Date = DateTime.Now.AddDays(-10).AddHours(-3), SessionName = "Test Session 2", Latitude = 21, Longitude = 2 });
            modelBuilder.Entity<Session>().HasData(new Session { Id = 3, Date = DateTime.Now.AddDays(-43).AddHours(15), SessionName = "Test Session 3", Latitude = 5, Longitude = 54 });
        }
    }
}
