using POC_Lazy_Eager.Models;

namespace POC_Lazy_Eager.Repositories
{
    public interface IRepository<T>
    {
        public IQueryable<T> GetAll();
    }
}
