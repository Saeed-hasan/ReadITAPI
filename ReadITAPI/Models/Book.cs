using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReadITAPI.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int book_ISBN { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Book_Title { get; set; }
        [Required]
        public string Book_Author { get; set; }
        public string Book_Description { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        [Range(0, 1000)]
        public decimal price { get; set; }
        public int copies { get; set; }
        public int category_id { get; set; }
        [ForeignKey(nameof(category_id))]
        public Category? category { get; set; }
        public int fk_Publisher_id { get; set; }
        [ForeignKey(nameof(fk_Publisher_id))]
        public Publisher? Publisher { get; set; }
    }
}
