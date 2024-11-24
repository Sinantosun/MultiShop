using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.BrandDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.CatalogComponents
{
    public class CatalogVendorComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CatalogVendorComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(result);
            }
            return View(new List<ResultBrandDto>());
        }
    }
}
