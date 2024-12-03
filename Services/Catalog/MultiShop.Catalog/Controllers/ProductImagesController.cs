using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImagesService;

        public ProductImagesController(IProductImageService ProductImagesService)
        {
            _productImagesService = ProductImagesService;
        }
        [HttpGet("GetProductImageListByProductId")]
        public async Task<IActionResult> GetProductImageListByProductId(string productId)
        {
            var values = await _productImagesService.GetProductImagesByProductId(productId);
            return Ok(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _productImagesService.GetAllProductImageAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _productImagesService.GetProductImageByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductImageDto createProductImagesDto)
        {
            await _productImagesService.CreateProductImageAsync(createProductImagesDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductImageDto updateProductImagesDto)
        {
            await _productImagesService.UpdateProductImageAsync(updateProductImagesDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productImagesService.DeleteProductImageAsync(id);
            return Ok();
        }
    }
}
