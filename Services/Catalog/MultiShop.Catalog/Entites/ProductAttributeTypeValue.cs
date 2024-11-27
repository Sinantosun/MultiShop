using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entites
{
    public class ProductAttributeTypeValue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductAttributeTypeValueId { get; set; }
      


        public string ProductId { get; set; }
        public string ProductAttributeTypeId { get; set; }
        public string AttributeValue { get; set; }

    }
}
