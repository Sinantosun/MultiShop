using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            ///http://localhost:7070/api/ProductImages

            var response = await _httpClient.PostAsJsonAsync<CreateProductImageDto>("ProductImages", createProductImageDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProductImageAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"ProductImages/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductImageDto>>("ProductImages");
            return values;
        }

        public async Task<ResultProductImageByIdDto> GetProductImageByIdAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<ResultProductImageByIdDto>($"ProductImages/{id}");
            return values;
        }

        public async Task<ResultProductImageByProductIdDto> GetProductImagesByProductId(string productId)
        {
            var values = await _httpClient.GetFromJsonAsync<ResultProductImageByProductIdDto>($"ProductImages/GetProductImageListByProductId?productId={productId}");
            return values;
        }

        public async Task<bool> UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("ProductImages", updateProductImageDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
