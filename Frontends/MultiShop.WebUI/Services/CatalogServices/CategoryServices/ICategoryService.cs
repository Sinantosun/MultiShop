using MultiShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<ResultCategoryByIdDto> GetCategoryByIdAsync(string id);

        Task<List<ResultCategoryWithCountDto>> GetCategoriesWithCountsAsync();
    }
}
