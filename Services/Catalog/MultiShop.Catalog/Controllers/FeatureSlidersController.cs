using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _FeatureSliderService;

        public FeatureSlidersController(IFeatureSliderService FeatureSliderService)
        {
            _FeatureSliderService = FeatureSliderService;
        }
        [HttpGet("GetActiveList")]
        public async Task<IActionResult> GetActiveList()
        {
            var values = await _FeatureSliderService.GetTrueFeatureSliderListAsync();
            return Ok(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _FeatureSliderService.GetAllFeatureSliderAsync();
            return Ok(values);
        }
        [HttpGet("ChangStatusToFalse")]
        public async Task<IActionResult> ChangStatusToFalse(string id)
        {
            await _FeatureSliderService.ChangeFeatureSliderStatusToFalse(id);
            return Ok();
        }
        [HttpGet("ChangStatusToTrue")]
        public async Task<IActionResult> ChangStatusToTrue(string id)
        {
            await _FeatureSliderService.ChangeFeatureSliderStatusToTrue(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _FeatureSliderService.GetFeatureSliderByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _FeatureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _FeatureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _FeatureSliderService.DeleteFeatureSliderAsync(id);
            return Ok();
        }
    }
}
