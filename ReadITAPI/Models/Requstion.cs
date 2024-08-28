using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReadITAPI.Models
{
    public class Requstion
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public int fk_book_ISBN { get; set; }
        [ForeignKey(nameof(fk_book_ISBN))]
        public Book book { get; set; }
        public int fk_Publisher_id { get; set; }
        [ForeignKey(nameof(fk_Publisher_id))]
        public Publisher Publisher { get; set; }
    }
}
