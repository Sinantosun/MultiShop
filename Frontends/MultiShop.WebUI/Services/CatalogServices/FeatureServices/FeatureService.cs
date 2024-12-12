using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //Feature
        public async Task<bool> CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateFeatureDto>("Feature", createFeatureDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteFeatureAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"Feature/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<ResultFeatueDto>> GetAllFeatureAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultFeatueDto>>("Feature");
            return values;
        }

        public async Task<ResultFeatureByIdDto> GetFeatureByIdAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<ResultFeatureByIdDto>($"Feature/{id}");
            return values;
        }

        public async Task<bool> UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("Feature", updateFeatureDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
