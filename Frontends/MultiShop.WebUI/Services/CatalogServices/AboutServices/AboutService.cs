using MultiShop.DtoLayer.Dtos.CatalogDtos.AboutDtos;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateAboutDto>("Abouts", createAboutDto);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAboutAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"Abouts/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<ResultAboutByIdDto> GetAboutByIdAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<ResultAboutByIdDto>($"Abouts/{id}");
            return values;
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultAboutDto>>("Abouts");
            return values;
        }

        public async Task<bool> UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateAboutDto>("Abouts", updateAboutDto);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
