namespace YourNamespace.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string RegistrationNumber { get; set; }
    }

    public class OilFuelCar : Car
    {
        public double TankCapacity { get; set; }
        public object BatteryCapacity { get; internal set; }
    }

    public class ElectricCar : Car
    {
        public double BatteryCapacity { get; set; }
    }
}
