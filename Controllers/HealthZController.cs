using Microsoft.AspNetCore.Mvc;
using NikeshBiraggari_002299909_01.Data;

namespace NikeshBiraggari_002299909_01.Controllers
{
    [Route("healthz")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class HealthZController : Controller
    {
        
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;
        public HealthZController(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetHealth()
        {
            try
            {
                //using (var mySqlConnection = new MySqlConnection(_configuration.GetConnectionString("HealthCheck")))
                //{
                //    mySqlConnection.Open();
                //    return Ok();
                //}
                if (_databaseContext.Database.CanConnect())
                {
                    if (HttpContext.Request.Query.Count > 0 || HttpContext.Request.ContentLength > 0)
                    {
                        //Response.Headers.Add(@"Content-Length", HttpContext.Request.Headers.ContentLength.ToString());
                        return BadRequest();
                    }

                    return Ok();
                }

                return BadRequest();
            }

            catch (Exception ex)
            {
                return StatusCode(503, ex.Message);
            }
        }
    }
}
