using MultiShop.DtoLayer.Dtos.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task<bool> CreateAboutAsync(CreateAboutDto createAboutDto);
        Task<bool> UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task<bool> DeleteAboutAsync(string id);
        Task<ResultAboutByIdDto> GetAboutByIdAsync(string id);
    }
}
