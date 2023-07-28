using IMS_API.Data;
using IMS_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FyearController : ControllerBase
    {
        public readonly IMSDbContext dbContext;
        public FyearController(IMSDbContext _dbcontext) 
        {
            dbContext = _dbcontext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<financial__YearSelection>> getall() 
        {
            var m_FY_YEAR= dbContext.M_FY_YEAR.ToList();
            return Ok(m_FY_YEAR);
        }

        [HttpGet("Company")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<financial__YearSelection>> get()
        {
            var companys = dbContext.M_COMPANY.ToList();
            return Ok(companys);
        }
        [HttpGet("CompanyId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<financial__YearSelection> getbyid(int COMPANY_ID)
        {
            var companys = dbContext.M_COMPANY.Where(l=>l.COMPANY_ID == COMPANY_ID).ToList();
            if(companys.Count==0) { return NotFound(companys); }
            return Ok(companys);
        }

        [HttpGet("FYEARID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<financial__YearSelection> getBYID(int FY_YEAR_ID)
        {
            var m_FY_YEAR = dbContext.M_FY_YEAR.Where(l=>l.FY_YEAR_ID == FY_YEAR_ID).ToList();
            if (m_FY_YEAR.Count == 0) { return NotFound(m_FY_YEAR); }
            return Ok(m_FY_YEAR);
        }
    }
}
