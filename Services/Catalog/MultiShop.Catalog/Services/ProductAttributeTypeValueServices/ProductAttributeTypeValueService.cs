using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MultiShop.Catalog.Dtos.ProductAttributeTypeValueDtos;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductAttributeTypeValueServices
{
    public class ProductAttributeTypeValueService : IProductAttributeTypeValueService
    {
        private readonly IMongoCollection<ProductAttributeTypeValue> _ProductAttributeTypeValueCollection;
        private readonly IMongoCollection<ProductAttributeType> _productAttrubiteType;
        private readonly IMapper _mapper;

        public ProductAttributeTypeValueService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _ProductAttributeTypeValueCollection = database.GetCollection<ProductAttributeTypeValue>(databaseSettings.ProductAttributeTypeValueCollectionName);
            _productAttrubiteType = database.GetCollection<ProductAttributeType>(databaseSettings.ProductAttributeTypeCollectionName);
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

        public async Task<List<ResultProductAttributeTypeValueByProductIdDto>> GetProductAttributeTypeValueByProductIdAsync()
        {
            //var filter = Builders<ProductAttributeTypeValue>.Filter.Eq("ProductId", productId);
            //var response = await _ProductAttributeTypeValueCollection.FindAsync(filter: filter);

            //var list = response.ToList().Select(t => new ResultProductAttributeTypeValueByProductIdDto
            //{
            //    AttributeName = _productAttrubiteType.Find(p => p.ProductAttributeTypeId == t.ProductAttributeTypeId).FirstOrDefault().TypeName,
            //    Values = _ProductAttributeTypeValueCollection.AsQueryable().Where(p => p.ProductAttributeTypeId == t.ProductAttributeTypeId).Select(o => new AttributeTypeValue
            //    {
            //        Value = o.AttributeValue.ToString(),
            //        IsExsit = 
            //    }).ToList(),

            //});

            //var filter = Builders<ProductAttributeType>.Filter.Empty;

            //var response = await _productAttrubiteType.FindAsync(filter: filter);

            //List<ResultProductAttributeTypeValueByProductIdDto> test = new List<ResultProductAttributeTypeValueByProductIdDto>();

            //var list = await response.ToListAsync();

            //foreach (var item in list)
            //{

            //    test.Add(new ResultProductAttributeTypeValueByProductIdDto
            //    {
            //        AttributeName = _productAttrubiteType.Find(p => p.ProductAttributeTypeId == item.ProductAttributeTypeId).FirstOrDefault().TypeName,
            //        Values = _ProductAttributeTypeValueCollection.AsQueryable().Where(p => p.ProductAttributeTypeId == item.ProductAttributeTypeId).Select(o => new AttributeTypeValue
            //        {
            //            Value = o.AttributeValue,
            //            IsExsit = (o.ProductAttributeTypeId == item.ProductAttributeTypeId ? true : false),

            //        }).ToList()
            //    });
            //}

            var filter = Builders<ProductAttributeType>.Filter.Empty;

            var response = await _productAttrubiteType.FindAsync(filter: filter);

            List<ResultProductAttributeTypeValueByProductIdDto> newlist = new List<ResultProductAttributeTypeValueByProductIdDto>();

            var list = await response.ToListAsync();

            foreach (var item in list)
            {
                newlist.Add(new ResultProductAttributeTypeValueByProductIdDto
                {
                    AttributeName = _productAttrubiteType.Find(p => p.ProductAttributeTypeId == item.ProductAttributeTypeId).FirstOrDefault().TypeName,
                    AttributeId = item.ProductAttributeTypeId,
                    Values = _ProductAttributeTypeValueCollection.AsQueryable().Select(o => new AttributeTypeValue
                    {
                        Value = o.AttributeValue,
                        IsExsit = (o.ProductAttributeTypeId == item.ProductAttributeTypeId ? true : false),
                   

                    }).ToList()
                });
            }

            return newlist.DistinctBy(t => t.AttributeName).ToList();

        }

        public async Task UpdateProductAttributeTypeValueAsync(UpdateProductAttributeTypeValueDto updateProductAttributeTypeValueDto)
        {
            var value = _mapper.Map<ProductAttributeTypeValue>(updateProductAttributeTypeValueDto);
            await _ProductAttributeTypeValueCollection.FindOneAndReplaceAsync(t => t.ProductAttributeTypeValueId == updateProductAttributeTypeValueDto.ProductAttributeTypeValueId, value);
        }
    }
}
