using Models;

namespace DataAccess.Repository.IRepository
{
    public interface ISessionRepository : IRepository<Session>
    {
        void Update(Session obj);
    }
}
