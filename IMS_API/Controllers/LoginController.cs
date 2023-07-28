using IMS_API.Data;
using IMS_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMSDbContext _dbcontext;

        public LoginController(IMSDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Login>> getall()
        {
            return _dbcontext.M_USER_MANAGEMENT.ToList();

        }

        [HttpGet("USER_NAME : String")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Login> Get(string USER_NAME)
        {
            if (string.IsNullOrEmpty(USER_NAME)) { return NotFound(); }
            var login_value = _dbcontext.M_USER_MANAGEMENT.Where(l => l.USER_NAME == USER_NAME).ToList();
            if (login_value == null) { return NoContent(); }
            return Ok(login_value);
        }
        [HttpPost("USER_NAME")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Login> Getbypassword(Login login)
        {
            if (string.IsNullOrEmpty(login.PASSWORD)) { return BadRequest(); }

            if (string.IsNullOrEmpty(login.USER_NAME)) { return NotFound(); }
            var login_value = _dbcontext.M_USER_MANAGEMENT.Where(l => l.USER_NAME == login.USER_NAME).ToList();
            var login_value1 = _dbcontext.M_USER_MANAGEMENT.Where(l => l.PASSWORD == login.PASSWORD ).ToList();
            var login_value2 = _dbcontext.M_USER_MANAGEMENT.Where(l => l.USER_NAME == login.USER_NAME).Where(l => l.PASSWORD == login.PASSWORD).ToList();
            if (login_value1.Count== 0) { return NotFound(); }
            if (login_value.Count == 0) { return NoContent(); }
            if(login_value2.Count == 0) { return NotFound(); }
            return Ok(login_value2);
        }

        //[HttpPost]
        //public ActionResult<Login> Create([FromBody] Login login_value)
        //{
        //    _dbcontext.M_USER_MANAGEMENT.Add(login_value);
        //   _dbcontext.SaveChanges();
        //    return CreatedAtAction("GetByUSER_NAME", new {USER_NAME = login_value.USER_NAME},login_value);
        //}

    }
}
