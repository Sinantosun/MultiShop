using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<ResultProductByIdDto> GetProductByIdAsync(string id);
        Task<List<ResultProductWithCategoriesDto>> GetProductWithCategoriesAsync(); 
        Task<List<GetProductsByCategoryIdDto>> GetProductListByCategoryIdAsync(string categoryId);



        Task<List<ResultProductWithAttrubtuitesDto>> GetProductAttrubitesByProductIdAsync(string productId);
        Task<ResultProductNameByProductIdDto> GetProductNameByProductId(string productId);

    }
}
