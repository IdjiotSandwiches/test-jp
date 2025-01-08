using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class TrInvoice
    {
        [Key]
        [Required]
        public required string InvoiceNo { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public required string InvoiceTo { get; set; }
        [Required]
        public required string ShipTo { get; set; }
        [Required]
        public int SalesID { get; set; }
        [Required]
        public int CourierID { get; set; }
        [Required]
        public int PaymentType { get; set; }
        [Required]
        public decimal CourierFee { get; set; }
    }
}
