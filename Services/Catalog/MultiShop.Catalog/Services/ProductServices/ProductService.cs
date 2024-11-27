using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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
        private readonly IMongoCollection<ProductAttributeType> _productAttributeType;
        private readonly IMongoCollection<ProductAttributeTypeValue> _productAttributeTypeValue;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _productAttributeType = database.GetCollection<ProductAttributeType>(databaseSettings.ProductAttributeType);
            _productAttributeTypeValue = database.GetCollection<ProductAttributeTypeValue>(databaseSettings.ProductAttributeTypeValue);
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

        public async Task<List<GetProductsByCategoryIdDto>> GetProductListByCategoryIdAsync(string categoryId)
        {
            var values = await _productCollection.Find(t => t.CategoryId == categoryId).ToListAsync();
            return _mapper.Map<List<GetProductsByCategoryIdDto>>(values);
        }

        public async Task<List<ResultProductWithCategoriesDto>> GetProductWithCategoriesAsync()
        {
            //List<ResultProductWithCategoriesDto> result = new List<ResultProductWithCategoriesDto>();
            //var ProductValues = await _productCollection.Find(t => true).ToListAsync();
            //foreach (var item in ProductValues)
            //{
            //    var category1 = _categoryCollection.Find(t => true).ToList();
            //    var category = _categoryCollection.Find(t => t.Id == item.CategoryId).FirstOrDefault();
            //    if (category != null)
            //    {
            //        var mappedValue = _mapper.Map<ResultCategoryDto>(category);
            //        result.Add(new ResultProductWithCategoriesDto
            //        {
            //            Id = item.Id,
            //            ProductDescription = item.ProductDescription,
            //            ProductImageUrl = item.ProductImageUrl,
            //            ProductName = item.ProductName,
            //            ProductPrice = item.ProductPrice,
            //            Category = mappedValue,

            //        });
            //    }
            //}

            var ProductValues = await _productCollection.Find(t => true).ToListAsync();
            foreach (var item in ProductValues)
            {
                item.Category = _categoryCollection.Find(u => u.Id == item.CategoryId).FirstOrDefault();
            }
            return _mapper.Map<List<ResultProductWithCategoriesDto>>(ProductValues);

        }

        public async Task<List<ResultProductWithAttrubtuitesDto>> GetProductAttrubitesByProductIdAsync(string productId)
        {


            //var product = await _productCollection.Find(t => t.Id == productId).FirstOrDefaultAsync();

            //var AttrubtesList = await _productAttributeTypeValue.Find(t => t.ProductId == productId).ToListAsync();
            //var AttritesNames = AttrubtesList.DistinctBy(a => a.ProductAttributeTypeId).Select(b => new ResultProductWithAttrubtuitesDto
            //{
            //    CategoryId = product.CategoryId,
            //    ProductDescription = product.ProductDescription,
            //    ProductImageUrl = product.ProductImageUrl,
            //    ProductName = product.ProductName,
            //    ProductPrice = product.ProductPrice,
            //    ProductId = productId,
            //    AttrubuteName = _productAttributeType.Find(c => c.ProductAttributeTypeId == b.ProductAttributeTypeId).FirstOrDefault().TypeName,
            //    Attrubuties = _productAttributeTypeValue.AsQueryable().Where(u => u.ProductId == productId && u.ProductAttributeTypeId == b.ProductAttributeTypeId).Select(z => new ProductDetailAttrubiteDto()
            //    {
            //        TypeValue = z.AttributeValue,


            //    }).ToList(),

            //}).FirstOrDefault();

            //return AttritesNames;

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
