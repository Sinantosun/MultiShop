using MultiShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("SpecialOffers",createSpecialOfferDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> DeleteSpecialOfferAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"SpecialOffers/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = _httpClient.GetFromJsonAsync<List<ResultSpecialOfferDto>>("SpecialOffers");
            return values;
        }

        public Task<ResultSpecialOfferByIdDto> GetSpecialOfferByIdAsync(string id)
        {
            var values = _httpClient.GetFromJsonAsync<ResultSpecialOfferByIdDto>($"SpecialOffers/{id}");
            return values;
        }

        public async Task<bool> UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("SpecialOffers", updateSpecialOfferDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
