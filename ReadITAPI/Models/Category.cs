using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReadITAPI.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int category_id { get; set; }
        [MaxLength(50)]
        [MinLength(5)]
        public string category_name { get; set; }
        public List<Book> Books { get; set; }
    }
}
