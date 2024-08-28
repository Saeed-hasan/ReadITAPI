using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ReadITAPI.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int order_Id { get; set; }
        [Required]
        public int fk_book_ISBN { get; set; }
        [ForeignKey(nameof(fk_book_ISBN))]
        public Book book { get; set; }
        public string Application_UserId { get; set; }
        [ForeignKey(nameof(Application_UserId))]
        [ValidateNever]
        public ApplicationUser Application_User { get; set; }
    }
}
