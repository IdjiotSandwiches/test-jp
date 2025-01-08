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

        [HttpGet("{invoice_number}", Name = "GetInvoiceNumber")]
        public async Task<ActionResult<object>> GetInvoiceNumber(string invoice_number)
        {
            var invoice = await _invoiceHelper.GetInvoice(invoice_number);
            var sales = await _invoiceHelper.GetSales();
            var courier = await _invoiceHelper.GetCouriers();
            var payment = await _invoiceHelper.GetPayments();
            var items = await _invoiceHelper.GetItems(invoice_number);
            var courierFee = await _invoiceHelper.GetCourierFee();

            if (invoice == null)
            {
                return BadRequest();
            }

            return Ok(new {
                Invoice = invoice,
                Sales = sales,
                Courier = courier,
                Payment = payment,
                Items = items,
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
