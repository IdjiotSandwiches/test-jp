using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class MsSales
    {
        [Key]
        [Required]
        public int SalesID { get; set; }
        [Required]
        public required string SalesName { get; set; }
    }
}
