using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductAttributeTypeValueDtos;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductAttributeTypeValueServices
{
    public class ProductAttributeTypeValueService : IProductAttributeTypeValueService
    {
        private readonly IMongoCollection<ProductAttributeTypeValue> _ProductAttributeTypeValueCollection;
        private readonly IMapper _mapper;

        public ProductAttributeTypeValueService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _ProductAttributeTypeValueCollection = database.GetCollection<ProductAttributeTypeValue>(databaseSettings.ProductAttributeTypeValueCollectionName);
            _mapper = mapper;

        }

        public async Task CreateProductAttributeTypeValueAsync(CreateProductAttributeTypeValueDto createProductAttributeTypeValueDto)
        {
            var value = _mapper.Map<ProductAttributeTypeValue>(createProductAttributeTypeValueDto);
            await _ProductAttributeTypeValueCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAttributeTypeValueAsync(string id)
        {
            await _ProductAttributeTypeValueCollection.DeleteOneAsync(t => t.ProductAttributeTypeValueId == id);
        }

        public async Task<List<ResultProductAttributeTypeValueDto>> GetAllProductAttributeTypeValueAsync()
        {
            var values = await _ProductAttributeTypeValueCollection.Find(t => true).ToListAsync();
            return _mapper.Map<List<ResultProductAttributeTypeValueDto>>(values);
        }

        public async Task<ResultProductAttributeTypeValueByIdDto> GetProductAttributeTypeValueByIdAsync(string id)
        {
            var value = await _ProductAttributeTypeValueCollection.Find(t => t.ProductAttributeTypeValueId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductAttributeTypeValueByIdDto>(value);
        }

        public async Task UpdateProductAttributeTypeValueAsync(UpdateProductAttributeTypeValueDto updateProductAttributeTypeValueDto)
        {
            var value = _mapper.Map<ProductAttributeTypeValue>(updateProductAttributeTypeValueDto);
            await _ProductAttributeTypeValueCollection.FindOneAndReplaceAsync(t => t.ProductAttributeTypeValueId == updateProductAttributeTypeValueDto.ProductAttributeTypeValueId, value);
        }
    }
}
