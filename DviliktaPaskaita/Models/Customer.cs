using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace YourNamespace.Models
{
    public class Customer
    {
        [BsonId]
        public ObjectId CostumerId { get; set; }
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}