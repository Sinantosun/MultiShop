using MultiShop.DtoLayer.Dtos.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task<bool> CreateBrandAsync(CreateBrandDto createBrandDto);
        Task<bool> UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task<bool> DeleteBrandAsync(string id);
        Task<ResultBrandByIdDto> GetBrandByIdAsync(string id);
    }
}
