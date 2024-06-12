using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourNamespace.Models;

namespace FrontEnd.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly IRentAPIService _apiService;
        [BindProperty]
        public List<Customer> customer { get; set; }

        public CustomerModel(IRentAPIService service)
        {
            _apiService = service;
        }

        public void OnGet()
        {
            customer = _apiService.GetAllCustomer();

        }
    }
}
