using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class MsProduct
    {
        [Key]
        [Required]
        public int ProductID { get; set; }
        [Required]
        public required string ProductName { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
