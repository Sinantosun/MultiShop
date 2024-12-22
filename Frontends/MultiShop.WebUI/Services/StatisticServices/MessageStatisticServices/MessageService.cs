
namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetAllMessageCountAsync()
        {
            return await _httpClient.GetFromJsonAsync<int>("UserMessage/GetAllMessageCount");
        }
    }
}
