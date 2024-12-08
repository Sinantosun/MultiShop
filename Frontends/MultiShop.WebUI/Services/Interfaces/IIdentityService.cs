using MultiShop.DtoLayer.Dtos.IdentityDtos.LoginDtos;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignInAsync(SignInDto signInDto);
        Task<bool> GetRefreshToken();
    }
}
