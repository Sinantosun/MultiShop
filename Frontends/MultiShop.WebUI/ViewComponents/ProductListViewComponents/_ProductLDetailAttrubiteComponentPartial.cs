using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductLDetailAttrubiteComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductLDetailAttrubiteComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/Products/GetProductAttrubitesByProductId?productId={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultProductWithAttrubtuitesDto>>(jsonData);
                return View(result);
            }
            return View(new List<ResultProductWithAttrubtuitesDto>());
        }
    }
}
