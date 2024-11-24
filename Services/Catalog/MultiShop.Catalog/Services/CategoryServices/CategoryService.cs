using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(t => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<List<ResultCategoryWithCountDto>> GetCategoriesWithCountsAsync()
        {
            var categoryValues = await _categoryCollection.Find(t => true).ToListAsync();
      
            var categories = categoryValues.Select(item => new ResultCategoryWithCountDto
            {
                CategoryName = item.CategoryName,
                Id = item.Id,
                ImageUrl = item.ImageUrl,
                CategoryCount = (int)_productCollection.Find(t => t.CategoryId == item.Id).Count(),
            }).ToList();
            return categories;
        }

        public async Task<ResultCategoryByIdDto> GetCategoryByIdAsync(string id)
        {
            var value = await _categoryCollection.Find(t => t.Id == id).FirstOrDefaultAsync(); ;
            return _mapper.Map<ResultCategoryByIdDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.Id == updateCategoryDto.Id, values);
        }
    }
}
