using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCar.Models;

namespace RentCar.Pages
{
    public class CarSelectModel : PageModel
    {
        public void OnGet()
        {
            using (ApplicationContext db = new())
            {

            }
        }
    }
}
