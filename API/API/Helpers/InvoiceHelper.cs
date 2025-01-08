using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Helpers
{
    public class InvoiceHelper(AppDbContext dbContext)
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<TrInvoice?> GetInvoice(string invoice_number)
        {
            return await _dbContext.TrInvoice
                .FirstOrDefaultAsync(x => x.InvoiceNo == invoice_number);
        }

        public async Task<IEnumerable<MsSales>> GetSales()
        {
            return await _dbContext.MsSales
                .ToListAsync();
        }

        public async Task<IEnumerable<MsCourier>> GetCouriers()
        {
            return await _dbContext.MsCourier
                .ToListAsync();
        }

        public async Task<IEnumerable<MsPayment>> GetPayments()
        {
            return await _dbContext.MsPayment
                .ToListAsync();
        }

        public async Task<IEnumerable<object>> GetItems(string invoice_number)
        {
            return await _dbContext.TrInvoiceDetail
                .Join(_dbContext.MsProduct,
                    detail => detail.ProductID,
                    product => product.ProductID,
                    (detail, product) => new
                    {
                        detail,
                        product
                    })
                .Where(x => x.detail.InvoiceNo == invoice_number)
                .Select(x => new
                {
                    item = x.product.ProductName,
                    weight = x.detail.Weight,
                    qty = x.detail.Qty,
                    price = x.detail.Price,
                    total = x.detail.Qty * x.detail.Price
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<LtCourierFee>> GetCourierFee()
        {
            return await _dbContext.LtCourierFee
                .ToListAsync();
        }
    }
}
