using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<ProductAttributeType> _productAttributeType;
        private readonly IMongoCollection<ProductAttributeTypeValue> _productAttributeTypeValue;
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _productAttributeType = database.GetCollection<ProductAttributeType>(databaseSettings.ProductAttributeType);
            _productAttributeTypeValue = database.GetCollection<ProductAttributeTypeValue>(databaseSettings.ProductAttributeTypeValue);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;

        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = new Product()
            {
                CategoryId = createProductDto.CategoryId,
                ProductName = createProductDto.ProductName,
                ProductDescription = createProductDto.ProductDescription,
                ProductImageUrl = createProductDto.ProductImageUrl,
                ProductPrice = createProductDto.ProductPrice,
            };
            await _productCollection.InsertOneAsync(product);

            var productId = product.Id;

            var productDetail = new ProductDetail()
            {
                ProductDescription = createProductDto.ProductDetailDescription,
                ProductId = productId,
                ProductInfo = createProductDto.ProductInfo,
            };
            await _productDetailCollection.InsertOneAsync(productDetail);

            var producrSliderImage = new ProductImage()
            {
                ProductId = product.Id,
                Image1 = createProductDto.Image1,
                Image2 = createProductDto.Image2,
                Image3 = createProductDto.Image3,
                Image4 = createProductDto.Image4,
                
            };
            await _productImageCollection.InsertOneAsync(producrSliderImage);

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

        public async Task<List<GetProductsByCategoryIdDto>> GetProductListByCategoryIdAsync(string categoryId)
        {
            var values = await _productCollection.Find(t => t.CategoryId == categoryId).ToListAsync();
            return _mapper.Map<List<GetProductsByCategoryIdDto>>(values);
        }

        public async Task<List<ResultProductWithCategoriesDto>> GetProductWithCategoriesAsync()
        {

            var ProductValues = await _productCollection.Find(t => true).ToListAsync();
            return ProductValues.Select(t => new ResultProductWithCategoriesDto
            {
                ProductDescription = t.ProductDescription,

                ProductImageUrl = t.ProductImageUrl,
                ProductName = t.ProductName,
                ProductId = t.Id,
                Category = _mapper.Map<ResultCategoryDto>(_categoryCollection.Find(u => u.Id == t.CategoryId).FirstOrDefault()),
                ProductPrice = t.ProductPrice,


            }).ToList();

        }

        public async Task<List<ResultProductWithAttrubtuitesDto>> GetProductAttrubitesByProductIdAsync(string productId)
        {


            var product = await _productCollection.Find(t => t.Id == productId).FirstOrDefaultAsync();

            var AttrubtesList = await _productAttributeTypeValue.Find(t => t.ProductId == productId).ToListAsync();
            var AttritesNames = AttrubtesList.DistinctBy(a => a.ProductAttributeTypeId).Select(b => new ResultProductWithAttrubtuitesDto
            {

                TypeName = _productAttributeType.Find(c => c.ProductAttributeTypeId == b.ProductAttributeTypeId).FirstOrDefault().TypeName,
                Attrubuties = _productAttributeTypeValue.AsQueryable().Where(u => u.ProductId == productId && u.ProductAttributeTypeId == b.ProductAttributeTypeId).Select(z => new ProductDetailAttrubiteDto()
                {
                    TypeValue = z.AttributeValue,


                }).ToList(),

            }).ToList();

            return AttritesNames;



        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(t => t.Id == updateProductDto.Id, value);
        }
    }
}
