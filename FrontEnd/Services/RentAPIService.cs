using FrontEnd.Pages;
using System.Text.Json;
using WebApplication3;
using YourNamespace.Models;
using static FrontEnd.Services.RentAPIService;

namespace FrontEnd.Services
{
    public class RentAPIService : IRentAPIService
    {
        private readonly string _apiBase;
        private readonly HttpClient _httpClient;
        public RentAPIService(string apibase)
        {
            _apiBase = apibase;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_apiBase);
        }
        public List<Cars> GetAllCars()
        {
            string path = "GetAllCars";
            HttpResponseMessage response = _httpClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<List<Cars>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
            }
            return new List<Cars>();
        }

        public List<Customer> GetAllCustomer()
        {
            string path = "GetAllCostumres";
            HttpResponseMessage response = _httpClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<List<Customer>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return new List<Customer>();
        }
        public List<Rental> GetAllRentals()
        {
            string path = "GetAllRentals";
            HttpResponseMessage response = _httpClient.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<List<Rental>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return new List<Rental>();
        }

    }
}
