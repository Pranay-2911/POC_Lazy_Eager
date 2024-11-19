using Microsoft.EntityFrameworkCore;
using POC_Lazy_Eager.Models;
using POC_Lazy_Eager.Repositories;

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
            return _repository.GetAll().ToList();
        }

        public List<Director> GetAllByEager()
        {

            return _repository.GetAll().Include(d=> d.Movies).ToList();
        }
    }
}
