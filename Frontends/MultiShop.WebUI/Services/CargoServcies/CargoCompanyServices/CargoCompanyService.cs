using MultiShop.DtoLayer.Dtos.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServcies.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateCargoAsync(CreateCargoDto createCargoDto)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateCargoDto>("CargoCompanies", createCargoDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCargoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"CargoCompanies/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<ResultCargoDto>> GetAllCargoAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultCargoDto>>("CargoCompanies");
            return response;
        }

        public async Task<ResultCargoByIdDto> GetCargoByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ResultCargoByIdDto>($"CargoCompanies/{id}");
            return response;
        }

        public async Task<bool> UpdateCargoAsync(UpdateCargoDto updateCargoDto)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateCargoDto>("CargoCompanies", updateCargoDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
