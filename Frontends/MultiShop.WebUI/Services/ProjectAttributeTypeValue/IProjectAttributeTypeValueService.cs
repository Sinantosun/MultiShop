using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductAttributeTypeValueDtos;

namespace MultiShop.WebUI.Services.ProjectAttributeTypeValue
{
    public interface IProjectAttributeTypeValueService
    {
        Task<List<ResultProductAttributeTypeValueDto>> GetAllProductAttributeTypeValueAsync();
        Task CreateProductAttributeTypeValueAsync(CreateProductAttributeTypeValueDto createIProductAttributeTypeValueDto);
        Task UpdateProductAttributeTypeValueAsync(UpdateProductAttributeTypeValueDto updateIProductAttributeTypeValueDto);
        Task DeleteProductAttributeTypeValueAsync(string id);
        Task<ResultProductAttributeTypeValueByIdDto> GetProductAttributeTypeValueByIdAsync(string id);

        Task<List<ResultProductAttributeTypeValueByProductIdDto>> GetProductAttributeTypeValueByProductIdAsync();

    }
}
