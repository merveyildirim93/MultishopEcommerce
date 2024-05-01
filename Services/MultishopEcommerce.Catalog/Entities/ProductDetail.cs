using MongoDB.Bson.Serialization.Attributes;

namespace MultishopEcommerce.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductDetailID { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public string ProductID { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
