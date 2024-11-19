using POC_Lazy_Eager.Models;

namespace POC_Lazy_Eager.Services
{
    public interface IDirectorService
    {
        public List<Director> GetAllByLazy();
        public List<Director> GetAllByEager();
    }
}
