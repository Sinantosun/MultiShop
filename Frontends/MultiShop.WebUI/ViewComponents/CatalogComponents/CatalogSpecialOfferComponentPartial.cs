using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.CatalogComponents
{
    public class CatalogSpecialOfferComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CatalogSpecialOfferComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/SpecialOffers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(result);
            }
            return View(new List<ResultSpecialOfferDto>());
        }
    }
}
