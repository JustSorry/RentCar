using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCar.Models;

namespace RentCar.Pages
{
    public class CarSelectModel : PageModel
    {
        public Car[] ResCars = new Car[0];
        public static string? CarBody;

        public void OnGet()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Car[] carArray = db.Cars.ToArray();
                ResCars = (from car in carArray where FilterCar(car, CarBody ?? "") select car).ToArray();
            }
        }

        private bool FilterCar(Car car, string searchingCar)
        {
            bool isFinded =
                (car.CarBody?.Contains(searchingCar) ?? false);
            return isFinded;
        }
    }
}
