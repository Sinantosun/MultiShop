using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductAttributeTypeDtos;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductAttributeTypeServices
{
    public class ProductAttributeTypeService : IProductAttributeTypeService
    {
        private readonly IMongoCollection<ProductAttributeType> _productAttributeTypeCollection;
        private readonly IMapper _mapper;

        public ProductAttributeTypeService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productAttributeTypeCollection = database.GetCollection<ProductAttributeType>(databaseSettings.ProductAttributeType);
            _mapper = mapper;

        }

        public async Task CreateProductAttributeTypeAsync(CreateProductAttributeTypeDto createProductAttributeTypeDto)
        {
            var value = _mapper.Map<ProductAttributeType>(createProductAttributeTypeDto);
            await _productAttributeTypeCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAttributeTypeAsync(string id)
        {
            await _productAttributeTypeCollection.DeleteOneAsync(t => t.ProductAttributeTypeId == id);
        }

        public async Task<List<ResultProductAttributeTypeDto>> GetAllProductAttributeTypeAsync()
        {
            var values = await _productAttributeTypeCollection.Find(t => true).ToListAsync();
            return _mapper.Map<List<ResultProductAttributeTypeDto>>(values);
        }

        public async Task<ResultProductAttributeTypeByIdDto> GetProductAttributeTypeByIdAsync(string id)
        {
            var value = await _productAttributeTypeCollection.Find(t => t.ProductAttributeTypeId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductAttributeTypeByIdDto>(value);
        }

        public async Task UpdateProductAttributeTypeAsync(UpdateProductAttributeTypeDto updateProductAttributeTypeDto)
        {
            var value = _mapper.Map<ProductAttributeType>(updateProductAttributeTypeDto);
            await _productAttributeTypeCollection.FindOneAndReplaceAsync(t => t.ProductAttributeTypeId == updateProductAttributeTypeDto.ProductAttributeTypeId, value);
        }
    }
}
