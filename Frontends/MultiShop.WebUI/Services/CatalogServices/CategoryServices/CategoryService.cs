using MultiShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);

        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync($"categories?id={id}");
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
        }

        public async Task<List<ResultCategoryWithCountDto>> GetCategoriesWithCountsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCategoryWithCountDto>>("categories/GetCategoriesWithProductCount");
        }

        public async Task<ResultCategoryByIdDto> GetCategoryByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<ResultCategoryByIdDto>($"categories/{id}");
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", updateCategoryDto);
        }
    }
}
