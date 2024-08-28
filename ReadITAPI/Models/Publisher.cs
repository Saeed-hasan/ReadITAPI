using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReadITAPI.Models
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Publisher_Id { get; set; }
        [Required]
        public string Publisher_Name { get; set; }
        public string Publisher_Address { get; set; }
    }
}
