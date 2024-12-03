using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService ;

        public SpecialOffersController(ISpecialOfferService SpecialOfferService)
        {
            _specialOfferService  = SpecialOfferService;
        }
        //api yazildi kontorl edilcekç.
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _specialOfferService .GetAllSpecialOfferAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _specialOfferService .GetSpecialOfferByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService .CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService .UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _specialOfferService .DeleteSpecialOfferAsync(id);
            return Ok();
        }
    }
}
