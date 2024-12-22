using MultiShop.DtoLayer.Dtos.CommentDtos;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateComment(CreateUserCommentDto createUserCommentDto)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateUserCommentDto>("Comments", createUserCommentDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteComment(int id)
        {
            var response = await _httpClient.DeleteAsync($"Comments/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<ResultUserCommentByIdDto> GetCommentById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ResultUserCommentByIdDto>($"Comments/{id}");
            return response;
        }

        public async Task<ResultProductReviewByProductIdDto> GetCommentListByProductId(string productId)
        {
             var response = await _httpClient.GetFromJsonAsync<ResultProductReviewByProductIdDto>($"Comments/GetCommentListByProductId?productId={productId}");
            return response;
        }

        public async Task<List<ResultUserCommentDto>> GetComments()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultUserCommentDto>>("Comments");
            return response;
        }

        public async Task<bool> UpdateComment(UpdateUserCommentDto updateUserCommentDto)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateUserCommentDto>("Comments", updateUserCommentDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
