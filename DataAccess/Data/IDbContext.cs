using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Data
{
    public interface IDbContext
    {
        DbSet<Session> Sessions { get; }
        DbSet<Catch> Catches { get; }
        DbSet<T> Set<T>() where T : class;
    }
}
