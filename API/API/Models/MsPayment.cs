using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class MsPayment
    {
        [Key]
        [Required]
        public int PaymentID { get; set; }
        [Required]
        public required string PaymentName { get; set; }
    }
}
