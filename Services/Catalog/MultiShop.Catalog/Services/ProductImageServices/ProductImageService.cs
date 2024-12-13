using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;
using static MongoDB.Driver.WriteConcern;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollcetion;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productImageCollcetion = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollcetion.InsertOneAsync(values);

        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollcetion.DeleteOneAsync(t => t.Id == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productImageCollcetion.Find(t => true).ToListAsync();
            return values.Select(t => new ResultProductImageDto
            {
                ProductImageId = t.Id,
                Image1 = t.Image1,
                Image2 = t.Image2,
                Image3 = t.Image3,
                Image4 = t.Image4,
                ProductId = t.ProductId

            }).ToList();
        }

        public async Task<ResultProductImageByIdDto> GetProductImageByIdAsync(string id)
        {
            var values = await _productImageCollcetion.Find(t => t.Id == id).FirstOrDefaultAsync();
            return new ResultProductImageByIdDto
            {
                ProductImageId = values.Id,
                Image1 = values.Image1,
                Image2 = values.Image2,
                Image3 = values.Image3,
                Image4 = values.Image4,
                ProductId = values.ProductId
            };
        }

        public async Task<ResultProductImageByProductIdDto> GetProductImagesByProductId(string productId)
        {
            var values = await _productImageCollcetion.Find(t => t.ProductId == productId).FirstOrDefaultAsync();
            if (values != null)
            {
                return new ResultProductImageByProductIdDto
                {
                    ProductImageId = values.Id,
                    Image1 = values.Image1,
                    Image2 = values.Image2,
                    Image3 = values.Image3,
                    Image4 = values.Image4,
                    ProductId = values.ProductId
                };
            }
            else
            {
                return new ResultProductImageByProductIdDto();
            }
        
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            ProductImage entity = new ProductImage
            {
                Id = updateProductImageDto.ProductImageId,
                Image1 = updateProductImageDto.Image1,
                Image2 = updateProductImageDto.Image2,
                Image3 = updateProductImageDto.Image3,
                Image4 = updateProductImageDto.Image4,
                ProductId = updateProductImageDto.ProductId
            };
            await _productImageCollcetion.FindOneAndReplaceAsync(t => t.Id == updateProductImageDto.ProductImageId, entity);
        }
    }
}
