using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCar.Models;

namespace RentCar.Pages.Admin
{
    [Authorize(policy: "adminRights")]
    public class AddCarModel : PageModel
    {
        public void OnPost(string brand, string model, string carBody, string yearOfProd, string driveType, string countryOfProd, string typeOfEngine, string engineV, string typeOfGearbox, string milleage, string dayPrice, string weekPrice )
        {
            using ApplicationContext db = new ApplicationContext();
            {
                Car car = new Car { Brand = brand, Model = model, CarBody = carBody, YearOfProd = Convert.ToInt32(yearOfProd), DriveType = driveType, CountryOfProd = countryOfProd, TypeOfEngine = typeOfEngine, EngineV = Convert.ToDouble(engineV), TypeOfGearbox = typeOfGearbox, Milleage = Convert.ToInt32(milleage), DayPrice = Convert.ToDouble(dayPrice), WeekPrice = Convert.ToDouble(weekPrice) };
                db.Cars.Add(car);               
                db.SaveChanges();
            }
        }
    }
}
