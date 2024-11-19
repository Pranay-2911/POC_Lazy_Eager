using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POC_Lazy_Eager.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        public virtual Director Director { get; set; }
        [ForeignKey("Director")]
        public int DirectorId { get; set; }


    }
}
