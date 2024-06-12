using WebApplication3;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourNamespace.Models;

namespace FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //[BindProperty]
        //public int VartotojoId { get; set; }
        [BindProperty]

        public List<Cars> Car { get; set; } = new List<Cars>();

        IRentAPIService _apiService;

        public IndexModel(ILogger<IndexModel> logger, IRentAPIService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        //public void OnGet()
        //{
        //    //Random random = new Random();
        //    //VartotojoId = random.Next(1, 100000);
        //    Car = _apiService.GetAllCars();
        //}



    }
}
