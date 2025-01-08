using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class MsCourier
    {
        [Key]
        [Required]
        public int CourierID { get; set; }
        [Required]
        public required string CourierName { get; set; }
    }
}
