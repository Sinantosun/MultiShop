using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ChangeFeatureSliderStatusToFalse(string id)
        {
            var response = await _httpClient.GetAsync($"FeatureSliders/ChangStatusToFalse?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ChangeFeatureSliderStatusToTrue(string id)
        {
            var response = await _httpClient.GetAsync($"FeatureSliders/ChangStatusToTrue?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var respose = await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("FeatureSliders", createFeatureSliderDto);
            if (respose.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> DeleteFeatureSliderAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"FeatureSliders/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultFeatureSliderDto>>("FeatureSliders");
            return response;
        }

        public async Task<ResultFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string id)
        {
            var response = await _httpClient.GetFromJsonAsync<ResultFeatureSliderByIdDto>($"FeatureSliders/{id}");
            return response;
        }

        public Task<List<ResultFeatureSliderDto>> GetTrueFeatureSliderListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var respose = await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("FeatureSliders", updateFeatureSliderDto);
            if (respose.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
