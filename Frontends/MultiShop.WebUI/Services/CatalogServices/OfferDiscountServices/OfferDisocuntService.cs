using MultiShop.DtoLayer.Dtos.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDisocuntService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDisocuntService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("OfferDiscounts", createOfferDiscountDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteOfferDiscountAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"OfferDiscounts/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var value = _httpClient.GetFromJsonAsync<List<ResultOfferDiscountDto>>("OfferDiscounts/");
            return value;
        }

        public Task<ResultOfferDiscountByIdDto> GetOfferDiscountByIdAsync(string id)
        {
            var value = _httpClient.GetFromJsonAsync<ResultOfferDiscountByIdDto>($"OfferDiscounts/{id}");
            return value;
        }

        public async Task<bool> UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDto>("OfferDiscounts", updateOfferDiscountDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
