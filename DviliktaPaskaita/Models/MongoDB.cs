using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DviliktaPaskaita.Models
{
    public class MongoDB
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}
