using IMS_API.Data;
using IMS_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceMainController : ControllerBase
    {
        public readonly IMSDbContext _dbcontext;
        public InvoiceMainController(IMSDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<T_InvoiceMain>> Get()
        {
            return _dbcontext.T_INVOICE_REPORT.ToList();
        }

        [HttpGet("Invoice : String")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<T_InvoiceMain> GetByInvoiceNo(String Invoice_no)
        {
            if (Invoice_no == null) { return NotFound(); }

            var Invoice_value = _dbcontext.T_INVOICE_REPORT.Where(l => l.Invoice_no == Invoice_no).ToList();
            if (Invoice_value == null) { return BadRequest(); }

            return Ok(Invoice_value);
        }
        [HttpGet("Company")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<T_QuotationMain> GetBYinvoice_no(int Company)
        {




            var Quotation_value = _dbcontext.T_INVOICE_REPORT.Where(l => l.customer_id == Company).ToList();

            if (Quotation_value == null)

                return NoContent();

            return Ok(Quotation_value);




        }
    }
}
