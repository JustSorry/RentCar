using BAL.Services;
using BAL.Interfaces;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages
{
    public class CarSelectModel : PageModel
    {
        private ICarService _carService;
        public Car[] ResCars;
        public new string? Request;
       
        public CarSelectModel(ICarService carService)
        {
            _carService = carService;
        }

        public void OnGet(string? req)
        {
            Request = req;
            Car[] carArray = _carService.GetAllCars().ToArray();
            ResCars = (from car in carArray where _carService.CheckCar(Request ?? "", car) select car).ToArray();
        }
    }
}
