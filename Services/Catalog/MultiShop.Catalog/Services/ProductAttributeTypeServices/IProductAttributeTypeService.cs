using MultiShop.Catalog.Dtos.ProductAttributeTypeDtos;

namespace MultiShop.Catalog.Services.ProductAttributeTypeServices
{
    public interface IProductAttributeTypeService
    {
        Task<List<ResultProductAttributeTypeDto>> GetAllProductAttributeTypeAsync();
        Task CreateProductAttributeTypeAsync(CreateProductAttributeTypeDto createProductAttributeTypeDto);
        Task UpdateProductAttributeTypeAsync(UpdateProductAttributeTypeDto updateProductAttributeTypeDto);
        Task DeleteProductAttributeTypeAsync(string id);
        Task<ResultProductAttributeTypeByIdDto> GetProductAttributeTypeByIdAsync(string id);
    }
}
