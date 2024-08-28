using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace ReadITAPI.Models
{
    public class ApplicationUser
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        [MaxLength(60)]
        public string name { get; set; }

        [Required]
        public decimal user_Balance { get; set; }
        public string StreetAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string city { get; set; }
        [Required]
        [MaxLength(50)]
        public string state { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string postalcode { get; set; }
        public int? fk_Publisher_id { get; set; }
        [ForeignKey(nameof(fk_Publisher_id))]
        [ValidateNever]
        public Publisher? Publisher { get; set; }
    }
}
