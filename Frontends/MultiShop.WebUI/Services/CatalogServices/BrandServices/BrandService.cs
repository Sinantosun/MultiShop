using MultiShop.DtoLayer.Dtos.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateBrandDto>("Brands", createBrandDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteBrandAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"Brands/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var value = _httpClient.GetFromJsonAsync<List<ResultBrandDto>>($"Brands");
            return value;
        }

        public Task<ResultBrandByIdDto> GetBrandByIdAsync(string id)
        {
            var value = _httpClient.GetFromJsonAsync<ResultBrandByIdDto>($"Brands/{id}");
            return value;
        }

        public async Task<bool> UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateBrandDto>("Brands", updateBrandDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
