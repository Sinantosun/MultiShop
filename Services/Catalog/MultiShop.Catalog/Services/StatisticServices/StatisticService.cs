using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;
        public StatisticService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
        }
        public int GetBrandCount()
        {
            return (int)_brandCollection.CountDocuments(FilterDefinition<Brand>.Empty);
        }

        public int GetCategoryCount()
        {
            return (int)_categoryCollection.CountDocuments(FilterDefinition<Category>.Empty);
        }

        public string GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(t => t.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("Id");

            var product = _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefault();
            return product.GetValue("ProductName").AsString;

        }

        public decimal GetMaxPriceProductPrice()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(t => t.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductPrice).Exclude("Id");

            var product = _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefault();
            return product.GetValue("ProductPrice").AsDecimal;
        }

        public string GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(t => t.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("Id");

            var product = _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefault();
            return product.GetValue("ProductName").AsString;
        }

        public decimal GetMinPriceProductPrice()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(t => t.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductPrice).Exclude("Id");

            var product = _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefault();
            return product.GetValue("ProductPrice").AsDecimal;
        }

        public decimal GetProductAvgPrice()
        {
            var pipline = new BsonDocument[]
            {
               new BsonDocument("$group",new BsonDocument
               {
                   {"_id","" },
                   {"ProductAvgPrice",new BsonDocument("$avg","$ProductPrice") }
               })
            };
            var result = _productCollection.Aggregate<BsonDocument>(pipline);
            var value = result.FirstOrDefault().GetValue("ProductAvgPrice", decimal.Zero).AsDecimal;
            return value;

            return _productCollection.AsQueryable().Average(t => t.ProductPrice);
        }

        public int GetProductCount()
        {
            return (int)_productCollection.CountDocuments(FilterDefinition<Product>.Empty);
        }

        public string LastInsertedProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(t => t.Id);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("Id");

            var product = _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefault();
            return product.GetValue("ProductName").AsString;


        }

    }
}
