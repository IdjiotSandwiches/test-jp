using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class LtCourierFee
    {
        [Key]
        [Required]
        public int WeightID { get; set; }
        [Required]
        public int CourierID { get; set; }
        [Required]
        public int StartKg { get; set; }
        [Required]
        public int EndKg { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
