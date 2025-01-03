﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService ProductService)
        {
            _productService = ProductService;
        }
        [HttpGet("GetProductNameByProductId/{id}")]
        public async Task<IActionResult> GetProductNameByProductId(string id)
        {
            var values = await _productService.GetProductNameByProductId(id);
            return Ok(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("GetProductAttrubitesByProductId")]
        public async Task<IActionResult> GetProductAttrubitesByProductId(string productId)
        {
            var values = await _productService.GetProductAttrubitesByProductIdAsync(productId);
            return Ok(values);
        }
        [HttpGet("GetProductListByCategoryId")]
        public async Task<IActionResult> GetProductListByCategoryId(string categoryId)
        {
            var values = await _productService.GetProductListByCategoryIdAsync(categoryId);
            return Ok(values);
        }
        [HttpGet("GetListWithCategories")]
        public async Task<IActionResult> GetListWithCategories()
        {
            var values = await _productService.GetProductWithCategoriesAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _productService.GetProductByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }
    }
}
