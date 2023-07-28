using IMS_API.Data;
using IMS_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationItemController : ControllerBase
    {
        public readonly IMSDbContext _dbcontext;
        public QuotationItemController(IMSDbContext dbContext) 
        { 
            _dbcontext = dbContext;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<T_QUOTATION_ITEM>> Get()
        {
            return _dbcontext.T_QUOTATOIN_ITEM_REPORT.ToList();

        }

        [HttpGet("Quotation_no : String")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<T_QUOTATION_ITEM> GetByQuotationNo(string quotationNo)
        {
            if (string.IsNullOrEmpty(quotationNo)) { return NotFound(); }

            var Quotation_value = _dbcontext.T_QUOTATOIN_ITEM_REPORT.Where(l => l.Quotation_no == quotationNo).ToList();
            if (Quotation_value == null) { return NoContent(); }
            return Ok(Quotation_value);
        }
        //public async Task<ActionResult<T_QUOTATION_ITEM>> getall() 
        //{
        //    var Quotation_value = await _dbcontext.T_QUOTATION_ITEM_EXE.FromSqlRaw("EXEC T_QUOTATION_ITEM_EXE").ToListAsync();

        //    return Ok(Quotation_value);
    }
}

