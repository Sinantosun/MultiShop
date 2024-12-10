using MultiShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task<bool> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<bool> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<bool> DeleteCategoryAsync(string id);
        Task<ResultCategoryByIdDto> GetCategoryByIdAsync(string id);

        Task<List<ResultCategoryWithCountDto>> GetCategoriesWithCountsAsync();
    }
}
