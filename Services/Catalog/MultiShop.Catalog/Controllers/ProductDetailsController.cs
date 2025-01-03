﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService ProductDetailService)
        {
            _productDetailService = ProductDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("ProductDetailDescriptionByIdAsync")]
        public async Task<IActionResult> ProductDetailDescriptionByIdAsync(string productId)
        {
            var values = await _productDetailService.GetProductDescriptionByProductIdAsync(productId);
            return Ok(values);
        }
        [HttpGet("ProductDetailInfoByIdAsync")]
        public async Task<IActionResult> ProductDetailInfoByIdAsync(string productId)
        {
            var values = await _productDetailService.GetProductInfoByProductIdAsync(productId);
            return Ok(values);
        }
        [HttpGet("GetProductDetailByProductId")]
        public async Task<IActionResult> GetProductDetailByProductId(string id)
        {
            var value = await _productDetailService.GetProductDetailByProductIdAsync(id);
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _productDetailService.GetProductDetailByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok();
        }
    }
}
