using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Customer
    {
        [BsonId]
        [Key]
        [Column("CustomerId")]
        public ObjectId CostumerId { get; set; }
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}