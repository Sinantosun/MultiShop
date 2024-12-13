using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var response = await _httpClient.PutAsJsonAsync<CreateProductDetailDto>("ProductDetails", createProductDetailDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProductDetailAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"ProductDetails/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ResultProductDetailDto>>("ResultProductDetailDto");
            return result;
        }

        public async Task<ResultProductDescriptionByProductIdDto> GetProductDescriptionByProductIdAsync(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResultProductDescriptionByProductIdDto>($"ProductDetails/ProductDetailDescriptionByIdAsync?productId={id}");
            return result;
        }

        public async Task<ResultProductDetailByIdDto> GetProductDetailByIdAsync(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResultProductDetailByIdDto>($"ProductDetails/{id}");
            return result;
        }

        public async Task<ResultProductDetailByProductIdDto> GetProductDetailByProductIdAsync(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResultProductDetailByProductIdDto>($"ProductDetails/GetProductDetailByProductId?id={id}");
            return result;
        }

        public async Task<ResultProductInfoByProductIdDto> GetProductInfoByProductIdAsync(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResultProductInfoByProductIdDto>($"ProductDetails/ProductDetailInfoByIdAsync?productId={id}");
            return result;
        }

        public async Task<bool> UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("ProductDetails", updateProductDetailDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
