using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Images.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
