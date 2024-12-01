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
        Task<ResultProductDescriptionByProductIdDto> GetProductDescriptionByProductIdAsync(string id);
        Task<ResultProductInfoByProductIdDto> GetProductInfoByProductIdAsync(string id);

        Task<ResultProductDetailByProductIdDto> GetProductDetailByProductIdAsync(string id);
    }
}
