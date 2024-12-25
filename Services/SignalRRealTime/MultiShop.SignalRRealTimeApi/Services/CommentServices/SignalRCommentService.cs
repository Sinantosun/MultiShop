using System.Net.Http;

namespace MultiShop.SignalRRealTimeApi.Services.CommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly HttpClient _httpClient;

        public SignalRCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> TotalCommentAsync()
        {
            //return await _httpClient.GetFromJsonAsync<int>("Comments/GetTotalCommentCount");
            return await _httpClient.GetFromJsonAsync<int>("http://localhost:7075/api/CommentStatistics");
        }
    }
}
