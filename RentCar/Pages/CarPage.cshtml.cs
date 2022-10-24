using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCar.Models;

namespace RentCar.Pages
{
    public class CarPageModel : PageModel
    {
        public Car takedCar = null;
        public void OnGet(int Id)
        { 
            using (ApplicationContext db = new ApplicationContext())
            {
                Car[] allCars = db.Cars.ToArray();
                takedCar = findCar(allCars, Id);
            }
        }

        private Car findCar(Car[] cars, int id)
        {
            Car specificCar = null;
            foreach (Car car in cars)
            {
                if (car.Id == id) specificCar = car;
                if (takedCar != null) break;
            }
            return specificCar;
        }

        //public Car takedCar = null;
        //public void OnGet()
        //{
        //    string body = Request.Query["CarBody"];
        //    using (ApplicationContext db = new())
        //    {
        //        foreach (Car car in db.Cars/*.ToArray()*/)
        //        {
        //            if (car.CarBody == body)
        //            {
        //                takedCar = car;
        //                return;
        //            }
        //        }
        //    }
        //}
    }
}
