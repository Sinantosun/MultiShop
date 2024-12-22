
namespace MultiShop.WebUI.Services.StatisticServices.UserStatisticServices
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<int> GetUserAllCountAsync()
        {
            var response = _httpClient.GetFromJsonAsync<int>("/api/Statistic/GetUserCount");
            return response;
        }
    }
}
