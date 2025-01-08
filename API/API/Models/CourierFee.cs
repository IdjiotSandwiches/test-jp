using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CourierFee
    {
        [Key]
        [Required]
        public int CourierID { get; set; }
        [Required]
        public int WeightID { get; set; }
        [Required]
        public int StartKg { get; set; }
        [Required]
        public int EndKg { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
