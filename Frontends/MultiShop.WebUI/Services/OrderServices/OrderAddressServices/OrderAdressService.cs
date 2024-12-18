using MultiShop.DtoLayer.Dtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public class OrderAdressService : IOrderAdressService
    {
        private readonly HttpClient _httpClient;

        public OrderAdressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("addresses", createOrderAddressDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
