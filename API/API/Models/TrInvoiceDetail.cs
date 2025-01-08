using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class TrInvoiceDetail
    {
        [Key]
        [Required]
        public required string InvoiceNo { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public Int16 Qty { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
