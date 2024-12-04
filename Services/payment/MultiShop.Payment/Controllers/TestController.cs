using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("payment isteği çağrıldı");
        }
    }
}
