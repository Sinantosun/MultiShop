
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetBrandCount()
        {
            return await _httpClient.GetFromJsonAsync<int>("Statistics/GetBrandCount");
        }

        public async Task<int> GetCategoryCount()
        {
            return await _httpClient.GetFromJsonAsync<int>("Statistics/GetCategoryCount");
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var response = await _httpClient.GetAsync("Statistics/GetMaxPriceProductName");
            var result = await response.Content.ReadAsStringAsync();
            if (result.Length > 30)
            {
                result = result.Substring(0, result.Substring(0, 30).LastIndexOf(" ")) + "...";
            }
            return result;
        }

        public async Task<decimal> GetMaxPriceProductPrice()
        {
            return await _httpClient.GetFromJsonAsync<decimal>("Statistics/GetMaxPriceProductPrice");
        }

        public async Task<string> GetMinPriceProductName()
        {
            var response = await _httpClient.GetAsync("Statistics/GetMinPriceProductName");
            var result = await response.Content.ReadAsStringAsync();
            if (result.Length > 30)
            {
                result = result.Substring(0, result.Substring(0, 30).LastIndexOf(" ")) + "...";
            }
            return result;
        }

        public async Task<decimal> GetMinPriceProductPrice()
        {

            return await _httpClient.GetFromJsonAsync<decimal>("Statistics/GetMinPriceProductPrice");
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            return await _httpClient.GetFromJsonAsync<decimal>("Statistics/GetProductAvgPrice");
        }

        public async Task<int> GetProductCount()
        {
            return await _httpClient.GetFromJsonAsync<int>("Statistics/GetProductCount");
        }

        public async Task<string> LastInsertedProductName()
        {
            var response = await _httpClient.GetAsync("Statistics/LastInsertedProductName");
            var result = await response.Content.ReadAsStringAsync();
            if (result.Length > 30)
            {
                result = result.Substring(0, result.Substring(0, 30).LastIndexOf(" ")) + "...";
            }
            return result;
        }
    }
}
