using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourNamespace.Models;

namespace FrontEnd.Pages
{
    public class Rentals : PageModel
    {
        
         private readonly IRentAPIService _apiService;
        [BindProperty]
        public List<Rental> rental { get; set; }

        public Rentals(IRentAPIService service)
        {
            _apiService = service;
        }

        public void OnGet()
        {
            rental = _apiService.GetAllRentals();

        }

    }
}
