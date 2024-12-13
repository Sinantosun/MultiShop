using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductLDetailAttrubiteComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        public _ProductLDetailAttrubiteComponentPartial(IHttpClientFactory httpClientFactory, IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var result = await _productService.GetProductAttrubitesByProductIdAsync(id);
            if (result != null)
            {
                return View(result);

            }
            return View(new List<ResultProductWithAttrubtuitesDto>());
        }
    }
}
