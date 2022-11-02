using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Admin;

[Authorize(policy: "adminRights")]
    public class CarMngModel : PageModel
    {
        private ICarService _carService;
        private Car currentCar;
        public Car[] allCars;

        public CarMngModel(ICarService carService)
        {
            _carService = carService;
        }
       
        public async void OnGet(int id)
        {
            allCars = _carService.GetAllCars().ToArray();
            currentCar = await _carService.GetCar(id);
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    allCars = db.Cars.ToArray();
            //    foreach (Car car in allCars)
            //    {
            //        if (car.Id == id)
            //        {
            //            currentCar = car;
            //            break;
            //        }
            //    }
            //}
        }
    }
    
