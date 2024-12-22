using MultiShop.DtoLayer.Dtos.IdentityDtos.UserDtos;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfoAsync();
        Task<List<ResultUserDto>> GetUserListAsync();
    }
}
