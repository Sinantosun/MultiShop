using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductAttributeTypeDtos;

namespace MultiShop.WebUI.Services.ProjectAttrubiteTypes
{
    public interface IProductAttrubiteTypeService
    {
        Task<List<ResultProductAttributeTypeDto>> GetAllProductAttributeTypeAsync();
        Task CreateProductAttributeTypeAsync(CreateProductAttributeTypeDto createProductAttributeTypeDto);
        Task UpdateProductAttributeTypeAsync(UpdateProductAttributeTypeDto updateProductAttributeTypeDto);
        Task DeleteProductAttributeTypeAsync(string id);
        Task<ResultProductAttributeTypeByIdDto> GetProductAttributeTypeByIdAsync(string id);
    }
}
