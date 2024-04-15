using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;

namespace DataAccess.Repository
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        private ApplicationDbContext _db;

        public SessionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Session obj)
        {
            _db.Update(obj);
        }
    }
}
