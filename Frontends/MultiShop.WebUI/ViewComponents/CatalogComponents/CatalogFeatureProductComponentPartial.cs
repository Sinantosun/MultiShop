using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.CatalogComponents
{
    public class CatalogFeatureProductComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        public CatalogFeatureProductComponentPartial( IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
          
            return View(values);
        }
    }
}
