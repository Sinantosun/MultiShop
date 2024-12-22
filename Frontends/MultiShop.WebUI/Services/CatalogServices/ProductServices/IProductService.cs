

using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<bool> CreateProductAsync(CreateProductDto createProductDto);
        Task<bool> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(string id);
        Task<ResultProductByIdDto> GetProductByIdAsync(string id);
        Task<List<ResultProductWithCategoriesDto>> GetProductWithCategoriesAsync(); 
        Task<List<GetProductsByCategoryIdDto>> GetProductListByCategoryIdAsync(string categoryId);


        Task<List<ResultProductWithAttrubtuitesDto>> GetProductAttrubitesByProductIdAsync(string productId);

        Task<ResultProductNameByProductIdDto> GetProductNameByProductId(string productId);

    }
}
