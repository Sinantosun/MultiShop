


using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using System.Net.Http.Json;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateProductAsync(CreateProductDto createProductDto)
        {
            var result = await _httpClient.PostAsJsonAsync<CreateProductDto>("products", createProductDto);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            var result = await _httpClient.DeleteAsync($"products/{id}");
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ResultProductDto>>("products");
            return result;
        }

        public async Task<List<ResultProductWithAttrubtuitesDto>> GetProductAttrubitesByProductIdAsync(string productId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ResultProductWithAttrubtuitesDto>>("/products/GetProductAttrubitesByProductId");
            return result;
        }

        public async Task<ResultProductByIdDto> GetProductByIdAsync(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResultProductByIdDto>($"products/{id}");
            return result;
        }

        public async Task<List<GetProductsByCategoryIdDto>> GetProductListByCategoryIdAsync(string categoryId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<GetProductsByCategoryIdDto>>($"products/GetProductListByCategoryId/{categoryId}");
            return result;
        }

        public async Task<List<ResultProductWithCategoriesDto>> GetProductWithCategoriesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoriesDto>>("products/GetListWithCategories");
            return result;
        }

        public async Task<bool> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var result = await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", updateProductDto);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
