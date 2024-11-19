
using Microsoft.EntityFrameworkCore;
using POC_Lazy_Eager.Data;
using POC_Lazy_Eager.Models;

namespace POC_Lazy_Eager.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DirectorContext _context;
        private readonly DbSet<T> _table;

        public Repository(DirectorContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }
    }
}
