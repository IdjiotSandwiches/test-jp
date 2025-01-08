using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TrInvoiceDetail> TrInvoiceDetail { get; set; }
        public DbSet<TrInvoice> TrInvoice { get; set; }
        public DbSet<LtCourierFee> LtCourierFee { get; set; }
        public DbSet<MsCourier> MsCourier { get; set; }
        public DbSet<MsPayment> MsPayment { get; set; }
        public DbSet<MsProduct> MsProduct { get; set; }
        public DbSet<MsSales> MsSales { get; set; }
    }
}
