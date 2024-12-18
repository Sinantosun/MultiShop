using MultiShop.DtoLayer.Dtos.OrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderingServices
{
    public class OrderingService : IOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string userId)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultOrderingByUserIdDto>>($"Orderings/GetOrderingByUserId/{userId}");
            return response;
        }
    }
}
