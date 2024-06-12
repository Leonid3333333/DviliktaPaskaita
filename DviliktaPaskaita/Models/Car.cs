using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace YourNamespace.Models
{
    public class Carz
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string RegistrationNumber { get; set; }
    }
    public class Cars
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string RegistrationNumber { get; set; }
    }

    public class OilFuelCar : Cars
    {
        public double TankCapacity { get; set; }
        public object BatteryCapacity { get; internal set; }
    }

    public class ElectricCar : Cars
    {
        public double BatteryCapacity { get; set; }
    }

}
