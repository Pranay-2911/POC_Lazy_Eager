using Microsoft.EntityFrameworkCore;
using POC_Lazy_Eager.Models;
using POC_Lazy_Eager.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POC_Lazy_Eager.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IRepository<Director> _repository;

        public DirectorService(IRepository<Director> repository)
        {
            _repository = repository;
        }
        public List<Director> GetAllByLazy()
        {
            // On-demand retrieval: Data is fetched when the navigation property is accessed.
            //Additional Queries: It triggers multiple queries to the database (N+1 query problem can occur).
            //Configuration: Requires UseLazyLoadingProxies() and navigation properties must be marked as virtual.

            return _repository.GetAll().ToList(); //by using UseLazyLoadingProxies()
        }

        public List<Director> GetAllByEager()
        {
            // the main difference in eager loading is that its use the Include KeyWord which 

            //Single Query: Uses Include to fetch related data in a single query.
            //Improved Performance: Minimizes the number of queries.
            //Explicit Fetching: The developer explicitly specifies the related data to be fetched.

            return _repository.GetAll().Include(d=> d.Movies).ToList();
        }
    }
}
