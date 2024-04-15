using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;

namespace DataAccess.Repository
{
    public class CatchRepository : Repository<Catch>, ICatchRepository
    {
        private ApplicationDbContext _db;

        public CatchRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Catch obj)
        {
            throw new NotImplementedException();
        }
    }
}
