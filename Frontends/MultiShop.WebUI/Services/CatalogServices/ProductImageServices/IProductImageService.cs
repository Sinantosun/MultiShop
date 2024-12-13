using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task<bool> CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task<bool> UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task<bool> DeleteProductImageAsync(string id);
        Task<ResultProductImageByIdDto> GetProductImageByIdAsync(string id);
        Task<ResultProductImageByProductIdDto> GetProductImagesByProductId(string productId);
    }
}
