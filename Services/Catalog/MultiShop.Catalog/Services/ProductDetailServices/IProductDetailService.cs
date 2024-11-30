using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<ResultProductDetailByIdDto> GetProductDetailByIdAsync(string id);
        Task<ResultProductDescriptionByProductIdDto> GetProductDescriptionByProductId(string id);
        Task<ResultProductInfoByProductIdDto> GetProductInfoByProductId(string id);
    }
}
