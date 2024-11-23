using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
  
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _FeatureService;

        public FeatureController(IFeatureService FeatureService)
        {
            _FeatureService = FeatureService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _FeatureService.GetAllFeatureAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _FeatureService.GetFeatureByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateFeatureDto createFeatureDto)
        {
            await _FeatureService.CreateFeatureAsync(createFeatureDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
        {
            await _FeatureService.UpdateFeatureAsync(updateFeatureDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _FeatureService.DeleteFeatureAsync(id);
            return Ok();
        }
    }
}
