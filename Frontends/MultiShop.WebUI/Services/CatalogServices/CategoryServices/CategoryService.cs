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

        public async Task<bool> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var result = await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> DeleteCategoryAsync(string id)
        {
            var result = await _httpClient.DeleteAsync($"categories/{id}");
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
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

        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var result = await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", updateCategoryDto);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
