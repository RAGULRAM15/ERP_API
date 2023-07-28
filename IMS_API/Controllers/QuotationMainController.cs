using AutoMapper;
using IMS_API.Data;
using IMS_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Text;

namespace IMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationMainController : ControllerBase
    {
        public readonly IMSDbContext _dbcontext;
        public readonly IMapper _mapper;
        public QuotationMainController(IMSDbContext dbContext,IMapper mapper) 
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Quotation>> GetQuotations()
        //{
        //    var quotations = _dbcontext.QUOTATION_VIEW
        //        .Select(q => new Quotation
        //        {
        //            QUOTATION_NO = q.QUOTATION_NO,
        //            QUOTATION_DATE = q.QUOTATION_DATE,
        //            company_id = q.company_id,
        //            Quantity_main = q.Quantity_main,
        //            discount_main = q.discount_main,
        //            Total_main = q.Total_main,
        //            user_name = q.user_name,
        //            customer_id = q.customer_id,
        //            QuotationItemValue = (List<QUOTATION_ITEM>)q.QuotationItemValue.Select(item => new List<QUOTATION_ITEM>() { new QUOTATION_ITEM()
        //            {
        //                Row_id = item.Row_id,
        //                Item_id = item.Item_id,
        //                Size_id = item.Size_id,
        //                Style = item.Style,
        //                Quantity = item.Quantity,
        //                Rate = item.Rate,
        //                discount = item.discount,
        //                Total = item.Total

        //            } })
        //         })
        //        .ToList();
        //    return Ok(quotations);
        //}
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<T_QuotationMain>> Get()
        {
            var quotation_value =   _dbcontext.T_QUOTATION_REPORT.ToList();
            return Ok(quotation_value);
        }

        [HttpGet("Company")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<T_QuotationMain> GetBYQuotation_no(int Company) 
        {

            


                var Quotation_value = _dbcontext.T_QUOTATION_REPORT.Where(l => l.customer_id == Company).ToList();

            if (Quotation_value == null)
                
                return NoContent();

            return Ok(Quotation_value);
    

            

        }

       

        //exec T_QUOTATION_EXE @company_id = 1,@QUOTATION_DATE='3/22/2023 12:00:00 AM',@DISCOUNT_MAIN = 0,@QUANTITY_MAIN = 2,
        //@TOTAL_MAIN = 200,@CUSTOMER_ID = 1,@USER_NAME = 'USER',@ROW_ID=1, @ITEM = 1 ,@SIZE=1,@STYLE_NAME='',@QUANTITY=2,@RATE=100,
        //@DISCOUNT=0,@TOTAL =200
        [HttpPost("Insert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] QuotationDTO q) 
        {
          //var q = _mapper.Map<Quotation> (QuotationDTO);
            if(q == null)
                return NotFound();

            var quotation_value = q.QuotationItemValue;
            var quotation_post = _dbcontext.Database.ExecuteSqlInterpolated($@"exec T_QUOTATION_MAIN_EXE {q.customer_id},{q.QUOTATION_DATE},
                 {q.discount_main},{q.Quantity_main},{q.Total_main},{q.customer_id},{q.user_name}");
            if (quotation_value != null && quotation_value.Count >0)
            {

                for (int i = 0; i < quotation_value.Count; i++)
                {
                    var row = quotation_value[i];
                    var quotation_item = _dbcontext.Database.ExecuteSqlInterpolated($@"EXEC T_QUOTATION_ITEM_EXE {q.company_id},{row.Row_id},{row.Item_id},{row.Size_id},
                    {row.Style},{row.Quantity},{row.Rate},{row.discount},{row.Total}");

                }
            }
            else
            {
                return BadRequest();
            }
            //var createroute = Url.Action(nameof(GetBYQuotation_no), "QuotationMainController", new { Quotation_no = q.QUOTATION_NO });
            //var createresoures = GetBYQuotation_no(q.QUOTATION_NO);
            //if(createresoures == null)
            //{
            //    return NotFound();
            //}
            //return CreatedAtAction(createroute,createresoures );
            return Ok();
        }
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(Quotation q)
        {
                        
            if (q == null)
                return NotFound();

            var quotation_value = q.QuotationItemValue;
            var quotation_post = _dbcontext.Database.ExecuteSqlInterpolated($@"exec T_QUOTATION_MAIN_UPDATE_EXE {q.QUOTATION_NO},{q.customer_id},{q.QUOTATION_DATE},
                 {q.discount_main},{q.Quantity_main},{q.Total_main},{q.customer_id},{q.user_name}");
            if (quotation_value != null && quotation_value.Count > 0)
            {

                for (int i = 0; i < quotation_value.Count; i++)
                {
                    var row = quotation_value[i];
                    var quotation_item = _dbcontext.Database.ExecuteSqlInterpolated($@"EXEC T_QUOTATION_ITEM_UPDATE_EXE {q.QUOTATION_NO}, {q.company_id},{row.Row_id},{row.Item_id},{row.Size_id},
                    {row.Style},{row.Quantity},{row.Rate},{row.discount},{row.Total}");

                }
            }
            else
            {
                return BadRequest();
            }
            //var createroute = Url.Action(nameof(GetBYQuotation_no), "QuotationMainController", new { Quotation_no = q.QUOTATION_NO });
            //var createresoures = GetBYQuotation_no(q.QUOTATION_NO);
            //if(createresoures == null)
            //{
            //    return NotFound();
            //}
            //return CreatedAtAction(createroute,createresoures );
            return NoContent();
        }
    }
}
