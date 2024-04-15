using Models;

namespace DataAccess.Repository.IRepository
{
    public interface ICatchRepository : IRepository<Catch>
    {
        public void Update(Catch obj);
    }
}
