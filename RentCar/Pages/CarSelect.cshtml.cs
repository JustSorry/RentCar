using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCar.Models;
using System.Reflection.Metadata.Ecma335;

namespace RentCar.Pages
{
    public class CarSelectModel : PageModel
    {
        public Car[] ResCars = new Car[0];
        public new string? Request;

        public void OnGet(string? CarBody, string? CountryOfProd)
        {
            Request = CarBody == "allBodies" ? CountryOfProd : (CountryOfProd == "allCountries" ? CarBody : CountryOfProd);
            using (ApplicationContext db = new ApplicationContext())
            {
                Car[] carArray = db.Cars.ToArray();
                ResCars = (from car in carArray where FilterCar(car, Request ?? "") select car).ToArray();
            }
        }

        private bool FilterCar(Car car, string searchingCar)
        {
            bool isFinded =
                (car.CarBody?.Contains(searchingCar) ?? false) ||
                (car.CountryOfProd?.Contains(searchingCar) ?? false);
            return isFinded;
        }
    }
}
