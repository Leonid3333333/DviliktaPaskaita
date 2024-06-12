namespace YourNamespace.Models
{
    public class Rental
    {
       // public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
       // public decimal Price { get; set; }
    }
}