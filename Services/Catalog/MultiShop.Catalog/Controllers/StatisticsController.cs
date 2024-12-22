using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }
        [HttpGet("GetMaxPriceProductPrice")]
        public IActionResult GetMaxPriceProductPrice()
        {
            var value = _statisticService.GetMaxPriceProductPrice();
            return Ok(value);
        }
        [HttpGet("GetMinPriceProductPrice")]
        public IActionResult GetMinPriceProductPrice()
        {
            var value = _statisticService.GetMinPriceProductPrice();
            return Ok(value);
        }
        [HttpGet("LastInsertedProductName")]
        public IActionResult LastInsertedProductName()
        {
            var value = _statisticService.LastInsertedProductName();
            return Ok(value);
        }
        [HttpGet("GetMaxPriceProductName")]
        public IActionResult GetMaxPriceProductName()
        {
            var value = _statisticService.GetMaxPriceProductName();
            return Ok(value);
        }
        [HttpGet("GetMinPriceProductName")]
        public IActionResult GetMinPriceProductName()
        {
            var value = _statisticService.GetMinPriceProductName();
            return Ok(value);
        }
        [HttpGet("GetBrandCount")]
        public  IActionResult GetBrandCount()
        {
            var value = _statisticService.GetBrandCount();
            return Ok(value);
        }

        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            var value = _statisticService.GetCategoryCount();
            return Ok(value);
        }

        [HttpGet("GetProductAvgPrice")]
        public IActionResult GetProductAvgPrice()
        {
            var value = _statisticService.GetProductAvgPrice();
            return Ok(value);
        }

        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            var value = _statisticService.GetProductCount();
            return Ok(value);
        }
    }
}
