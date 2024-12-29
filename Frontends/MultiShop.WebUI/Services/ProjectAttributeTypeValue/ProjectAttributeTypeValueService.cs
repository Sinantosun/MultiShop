using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductAttributeTypeValueDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.ProjectAttributeTypeValue
{
    public class ProjectAttributeTypeValueService : IProjectAttributeTypeValueService
    {
        private readonly HttpClient _httpClient;

        public ProjectAttributeTypeValueService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAttributeTypeValueAsync(CreateProductAttributeTypeValueDto createIProductAttributeTypeValueDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductAttributeTypeValueDto>("ProductAttributeTypeValue", createIProductAttributeTypeValueDto);
        }

        public async Task DeleteProductAttributeTypeValueAsync(string id)
        {
            await _httpClient.DeleteAsync($"ProductAttributeTypeValue?id={id}");
        }

        public async Task<List<ResultProductAttributeTypeValueDto>> GetAllProductAttributeTypeValueAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductAttributeTypeValueDto>>("ProductAttributeTypeValue");
        }

        public async Task<ResultProductAttributeTypeValueByIdDto> GetProductAttributeTypeValueByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<ResultProductAttributeTypeValueByIdDto>($"ProductAttributeTypeValue?id={id}");
        }

        public async Task<List<ResultProductAttributeTypeValueByProductIdDto>> GetProductAttributeTypeValueByProductIdAsync()
        {
            var response = await _httpClient.GetAsync("ProductAttributeTypeValue/GetAttributeListByProductId");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultProductAttributeTypeValueByProductIdDto>>(result);
        }

        public async Task UpdateProductAttributeTypeValueAsync(UpdateProductAttributeTypeValueDto updateIProductAttributeTypeValueDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateProductAttributeTypeValueDto>("ProductAttributeTypeValue", updateIProductAttributeTypeValueDto);
        }


    }
}
