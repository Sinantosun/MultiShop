using MultiShop.Catalog.Dtos.ProductAttributeTypeValueDtos;

namespace MultiShop.Catalog.Services.ProductAttributeTypeValueServices
{
    public interface IProductAttributeTypeValueService
    {
        Task<List<ResultProductAttributeTypeValueDto>> GetAllProductAttributeTypeValueAsync();
        Task CreateProductAttributeTypeValueAsync(CreateProductAttributeTypeValueDto createIProductAttributeTypeValueDto);
        Task UpdateProductAttributeTypeValueAsync(UpdateProductAttributeTypeValueDto updateIProductAttributeTypeValueDto);
        Task DeleteProductAttributeTypeValueAsync(string id);
        Task<ResultProductAttributeTypeValueByIdDto> GetProductAttributeTypeValueByIdAsync(string id);
    }
}
