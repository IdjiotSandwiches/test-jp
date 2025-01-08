using API.Data;
using API.Helpers;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController(AppDbContext dbContext, InvoiceHelper invoiceHelper, IMapper mapper) : ControllerBase
    {
        private readonly AppDbContext _dbContext = dbContext;
        private readonly InvoiceHelper _invoiceHelper = invoiceHelper;
        private readonly IMapper _mapper = mapper;

        [HttpGet("{invoice_number}", Name = "GetInvoiceNumber")]
        public async Task<ActionResult<TrInvoice>> GetInvoiceNumber(string invoice_number)
        {
            var invoice = await _dbContext.TrInvoice
                .FirstAsync(x => x.InvoiceNo == invoice_number);

            var sales = await _dbContext.MsSales
                .ToListAsync();

            var courier = await _dbContext.MsCourier
                .ToListAsync();

            var payment = await _dbContext.MsPayment
                .ToListAsync();

            var items = await _dbContext.TrInvoiceDetail
                .Join(_dbContext.MsProduct,
                    detail => detail.ProductID,
                    product => product.ProductID,
                    (detail, product) => new
                    {
                        detail, product
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

            return Ok(new {
                Invoice = invoice,
                Sales = sales,
                Courier = courier,
                Payment = payment,
                Items = items,
            });
        }
    }
}
