
namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetActiveCommentCountAsync()
        {
            return await _httpClient.GetFromJsonAsync<int>("Comments/GetActiveCommentCount");
        }

        public async Task<int> GetAllCommentCountAsync()
        {
            return await _httpClient.GetFromJsonAsync<int>("Comments/GetTotalCommentCount");
        }

        public async Task<int> GetPassiveCommentCountAsync()
        {
            return await _httpClient.GetFromJsonAsync<int>("Comments/GetPasiveCommentCount");
        }

        public async Task<string> MostCommentProductId()
        {
            var response = await _httpClient.GetAsync("Comments/GetMostCommenetProductId");
            var productId = await response.Content.ReadAsStringAsync();
            return productId;
        }
    }
}
