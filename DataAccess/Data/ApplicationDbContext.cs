using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Catch> Catches { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>().HasData(new Session { Id = 1, Date = new DateOnly(2024, 3, 2), SessionName = "Test Session 1", Latitude = 12, Longitude = 22 });
            modelBuilder.Entity<Session>().HasData(new Session { Id = 2, Date = new DateOnly(2023, 8, 23), SessionName = "Test Session 2", Latitude = 21, Longitude = 2 });
            modelBuilder.Entity<Session>().HasData(new Session { Id = 3, Date = new DateOnly(2023, 6, 12), SessionName = "Test Session 3", Latitude = 5, Longitude = 54 });
        }

        public DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
