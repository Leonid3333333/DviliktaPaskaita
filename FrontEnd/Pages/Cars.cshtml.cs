using WebApplication3;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourNamespace.Models;

namespace FrontEnd.Pages
{

    public class CarsModel : PageModel
    {
    private readonly IRentAPIService _apiService;
     [BindProperty]
        public List<Cars> Car { get; set; }

        public CarsModel(IRentAPIService service)
        {
            _apiService = service;
        }

        public void OnGet()
        {
            Car = _apiService.GetAllCars();

        }
    }
}
