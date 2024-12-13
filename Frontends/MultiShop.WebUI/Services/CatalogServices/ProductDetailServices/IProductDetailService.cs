using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task<bool> CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task<bool> UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task<bool> DeleteProductDetailAsync(string id);
        Task<ResultProductDetailByIdDto> GetProductDetailByIdAsync(string id);
        Task<ResultProductDescriptionByProductIdDto> GetProductDescriptionByProductIdAsync(string id);
        Task<ResultProductInfoByProductIdDto> GetProductInfoByProductIdAsync(string id);

        Task<ResultProductDetailByProductIdDto> GetProductDetailByProductIdAsync(string id);
    }
}
