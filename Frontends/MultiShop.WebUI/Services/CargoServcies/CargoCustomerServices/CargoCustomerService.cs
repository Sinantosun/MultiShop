using MultiShop.DtoLayer.Dtos.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServcies.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCargoCustomerByCustometIdDto> GetUserAddresByUserId(string userId)
        {
            var responese = await _httpClient.GetFromJsonAsync<GetCargoCustomerByCustometIdDto>($"CargoCustomers/GetUserAddresByUserId/{userId}");
            return responese;
        }
    }
}
