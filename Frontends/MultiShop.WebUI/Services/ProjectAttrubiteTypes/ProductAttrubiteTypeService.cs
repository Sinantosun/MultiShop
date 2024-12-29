using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductAttributeTypeDtos;

namespace MultiShop.WebUI.Services.ProjectAttrubiteTypes
{
    public class ProductAttrubiteTypeService : IProductAttrubiteTypeService
    {
        private readonly HttpClient _httpClient;

        public ProductAttrubiteTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAttributeTypeAsync(CreateProductAttributeTypeDto createProductAttributeTypeDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductAttributeTypeDto>("ProductAttributeTypes", createProductAttributeTypeDto);
        }

        public async Task DeleteProductAttributeTypeAsync(string id)
        {
            await _httpClient.DeleteAsync($"ProductAttributeTypes?id={id}");

        }

        public async Task<List<ResultProductAttributeTypeDto>> GetAllProductAttributeTypeAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductAttributeTypeDto>>("ProductAttributeTypes");
        }

        public async Task<ResultProductAttributeTypeByIdDto> GetProductAttributeTypeByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<ResultProductAttributeTypeByIdDto>($"ProductAttributeTypes?id={id}");
        }

        public async Task UpdateProductAttributeTypeAsync(UpdateProductAttributeTypeDto updateProductAttributeTypeDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateProductAttributeTypeDto>("ProductAttributeTypes", updateProductAttributeTypeDto);
        }
    }
}
