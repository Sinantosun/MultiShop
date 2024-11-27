using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entites
{
    public class ProductAttributeType 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductAttributeTypeId { get; set; }
        public string TypeName { get; set; } //Renk - Gb - Beden - vb.
    }
}
