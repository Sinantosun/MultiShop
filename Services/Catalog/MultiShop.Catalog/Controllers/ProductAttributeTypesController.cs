using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductAttributeTypeDtos;
using MultiShop.Catalog.Services.ProductAttributeTypeServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProductAttributeTypesController : ControllerBase
    {
        private readonly IProductAttributeTypeService _ProductAttributeTypesService;

        public ProductAttributeTypesController(IProductAttributeTypeService productAttributeTypesService)
        {
            _ProductAttributeTypesService = productAttributeTypesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _ProductAttributeTypesService.GetAllProductAttributeTypeAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _ProductAttributeTypesService.GetProductAttributeTypeByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductAttributeTypeDto createProductAttributeTypesDto)
        {
            await _ProductAttributeTypesService.CreateProductAttributeTypeAsync(createProductAttributeTypesDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductAttributeTypeDto updateProductAttributeTypesDto)
        {
            await _ProductAttributeTypesService.UpdateProductAttributeTypeAsync(updateProductAttributeTypesDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ProductAttributeTypesService.DeleteProductAttributeTypeAsync(id);
            return Ok();
        }
    }
}
