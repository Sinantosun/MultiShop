using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;
using static MongoDB.Driver.WriteConcern;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings, IMongoCollection<Category> categoryCollection)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = categoryCollection;
            _mapper = mapper;

        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(t => t.Id == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(t => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<ResultProductByIdDto> GetProductByIdAsync(string id)
        {
            var value = await _productCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductByIdDto>(value);
        }

        public async Task<List<ResultProductWithCategoriesDto>> GetProductWithCategoriesAsync()
        {
            List<ResultProductWithCategoriesDto> result = new List<ResultProductWithCategoriesDto>();
            var ProductValues = await _productCollection.Find(t => true).ToListAsync();
            foreach (var item in ProductValues)
            {
                var category = _categoryCollection.Find(t => t.Id == item.Id).FirstOrDefault();
                if (category != null)
                {
                    var mappedValue = _mapper.Map<ResultCategoryDto>(category);
                    result.Add(new ResultProductWithCategoriesDto
                    {

                        Id = item.Id,
                        ProductDescription = item.ProductDescription,
                        ProductImageUrl = item.ProductImageUrl,
                        ProductName = item.ProductName,
                        ProductPrice = item.ProductPrice,
                        Category = mappedValue,

                    });
                }
            }
            return result;






        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(t => t.Id == updateProductDto.Id, value);
        }
    }
}
