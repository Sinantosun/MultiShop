using MultiShop.DtoLayer.Dtos.CommentDtos;
using System.Net.Http;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<bool> CreateComment(CreateUserCommentDto createUserCommentDto);
        Task<bool> UpdateComment(UpdateUserCommentDto updateUserCommentDto);
        Task<ResultUserCommentByIdDto> GetCommentById(int id);
        Task<ResultProductReviewByProductIdDto> GetCommentListByProductId(string productId);
        Task<List<ResultUserCommentDto>> GetComments();
        Task<bool> DeleteComment(int id); 
    }
}
