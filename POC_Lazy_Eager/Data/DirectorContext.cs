using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using POC_Lazy_Eager.Models;

namespace POC_Lazy_Eager.Data
{
    public class DirectorContext :DbContext
    {
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DirectorContext(DbContextOptions<DirectorContext> options) : base(options)
        {
         
        }
    }
}
