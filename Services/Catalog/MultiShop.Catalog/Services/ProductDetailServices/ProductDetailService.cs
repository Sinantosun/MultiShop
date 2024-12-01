using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;
using static MongoDB.Driver.WriteConcern;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(t => t.Id == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productDetailCollection.Find(t => true).ToListAsync();
            return values.Select(t => new ResultProductDetailDto
            {
                ProductDetailId = t.Id,
                ProductDescription = t.ProductDescription,
                ProductId = t.ProductId,
                ProductInfo = t.ProductInfo,

            }).ToList();
        }

        public async Task<ResultProductDescriptionByProductIdDto> GetProductDescriptionByProductIdAsync(string id)
        {
            var value = await _productDetailCollection.Find(t => t.ProductId == id).FirstOrDefaultAsync();
            return new ResultProductDescriptionByProductIdDto
            {
                ProductDetailId = value.Id,
                ProductDescription = value.ProductDescription,
            };
        }

        public async Task<ResultProductDetailByIdDto> GetProductDetailByIdAsync(string id)
        {
            var values = await _productDetailCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
            return new ResultProductDetailByIdDto
            {
                ProductDescription = values.ProductDescription,
                ProductDetailId = values.Id,
                ProductInfo = values.ProductInfo,
                ProductId = values.ProductId,

            };
        }

        public async Task<ResultProductDetailByProductIdDto> GetProductDetailByProductIdAsync(string id)
        {
            var values = await _productDetailCollection.Find(t => t.ProductId == id).FirstOrDefaultAsync();
            return new ResultProductDetailByProductIdDto
            {
                ProductDescription = values.ProductDescription,
                ProductDetailId = values.Id,
                ProductInfo = values.ProductInfo,
                ProductId = values.ProductId,

            };
        }

        public async Task<ResultProductInfoByProductIdDto> GetProductInfoByProductIdAsync(string id)
        {
            var value = await _productDetailCollection.Find(t => t.ProductId == id).FirstOrDefaultAsync();
            return new ResultProductInfoByProductIdDto
            {
                ProductDetailId = value.Id,
                ProductInfo = value.ProductInfo,
            };
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            ProductDetail entity = new ProductDetail()
            {
                ProductDescription = updateProductDetailDto.ProductDescription,
                Id = updateProductDetailDto.ProductDetailId,
                ProductInfo = updateProductDetailDto.ProductInfo,
                ProductId = updateProductDetailDto.ProductId,
            };
            await _productDetailCollection.FindOneAndReplaceAsync(t => t.Id == updateProductDetailDto.ProductDetailId, entity);


        }
    }
}
