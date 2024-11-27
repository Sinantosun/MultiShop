using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductAttributeTypeValueDtos;
using MultiShop.Catalog.Services.ProductAttributeTypeValueServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProductAttributeTypeValueController : ControllerBase
    {
        private readonly IProductAttributeTypeValueService _ProductAttributeTypeValueService;

        public ProductAttributeTypeValueController(IProductAttributeTypeValueService ProductAttributeTypeValueService)
        {
            _ProductAttributeTypeValueService = ProductAttributeTypeValueService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _ProductAttributeTypeValueService.GetAllProductAttributeTypeValueAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _ProductAttributeTypeValueService.GetProductAttributeTypeValueByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductAttributeTypeValueDto createProductAttributeTypeValueDto)
        {
            await _ProductAttributeTypeValueService.CreateProductAttributeTypeValueAsync(createProductAttributeTypeValueDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductAttributeTypeValueDto updateProductAttributeTypeValueDto)
        {
            await _ProductAttributeTypeValueService.UpdateProductAttributeTypeValueAsync(updateProductAttributeTypeValueDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ProductAttributeTypeValueService.DeleteProductAttributeTypeValueAsync(id);
            return Ok();
        }
    }
}
