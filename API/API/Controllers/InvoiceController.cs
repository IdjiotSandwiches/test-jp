using API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController(InvoiceHelper invoiceHelper, IMapper mapper) : ControllerBase
    {
        private readonly InvoiceHelper _invoiceHelper = invoiceHelper;
        private readonly IMapper _mapper = mapper;

        [HttpGet("{invoice_number}")]
        public async Task<ActionResult<object>> GetInvoiceNumber(string invoice_number)
        {
            var invoice = await _invoiceHelper.GetInvoice(invoice_number);
            var items = await _invoiceHelper.GetItems(invoice_number);

            if (invoice == null)
            {
                return BadRequest();
            }

            return Ok(new {
                Invoice = invoice,
                Items = items
            });
        }

        [HttpGet]
        public async Task<ActionResult<object>> Init()
        {
            var sales = await _invoiceHelper.GetSales();
            var courier = await _invoiceHelper.GetCouriers();
            var payment = await _invoiceHelper.GetPayments();
            var courierFee = await _invoiceHelper.GetCourierFee();

            return Ok(new
            {
                Sales = sales,
                Courier = courier,
                Payment = payment,
                CourierFee = courierFee
            });
        }

        [HttpPut]
        public async Task<ActionResult<object>> UpdateInvoice()
        {

            return Ok();
        }
    }
}
