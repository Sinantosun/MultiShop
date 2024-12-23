
using System.Net.Http;

namespace MultiShop.SignalRRealTimeApi.Services.MessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetTotalMessageCountByReciverIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<int>($"UserMessage/GetTotalMessageCountByReciverId/{id}");
        }

    }
}
