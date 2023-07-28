using IMS_API.Data;
using IMS_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        public readonly IMSDbContext _dbcontext;
        public InvoiceItemController(IMSDbContext dbContext) 
        {
            _dbcontext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<T_InvoiceItem>> GetITEM()
        {
            return _dbcontext.T_INVOICE_ITEM_REPORT.ToList();

        }

        [HttpGet("Invoice_no : String")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<T_InvoiceItem> GetByInvoiceNo_item(string Invoice_no)
        {
            if(string.IsNullOrWhiteSpace(Invoice_no)) return NotFound();
            var Invoice_value = _dbcontext.T_INVOICE_ITEM_REPORT.Where(l => l.Invoice_no == Invoice_no).ToList();
            if(Invoice_value == null) return NoContent();
            return Ok(Invoice_value);
        }
    }
}
