using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;



namespace RentCar.Pages
{
    public class CatalogModel : PageModel
    {
        private readonly ILogger<CatalogModel> _logger;

        public CatalogModel(ILogger<CatalogModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
    }
}