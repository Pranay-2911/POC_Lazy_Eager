using System.ComponentModel.DataAnnotations;

namespace POC_Lazy_Eager.Models
{
    public class Director
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Movie> Movies { get; set; }


    }
}
