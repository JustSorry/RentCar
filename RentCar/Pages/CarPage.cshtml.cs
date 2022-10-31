using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Models;
using DAL.Data;
using BAL.Services;

namespace RentCar.Pages
{
    public class CarPageModel : PageModel
    {
        public Car takedCar = null;
        CarService carService = new CarService();
        public async Task OnGet(int Id)
        { 
            using (ApplicationContext db = new ApplicationContext())
            {
                Car[] allCars = db.Cars.ToArray();
                takedCar = await carService.GetCar(allCars, Id);
            }
        }
    }
}
