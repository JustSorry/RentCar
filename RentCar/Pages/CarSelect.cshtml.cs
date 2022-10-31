using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Models;
using DAL.Data;
using System.Reflection.Metadata.Ecma335;
using DAL.Repositories;
using BAL.Services;

namespace RentCar.Pages
{
    public class CarSelectModel : PageModel
    {
        public Car[] ResCars = new Car[0];
        public new string? Request;
        CarService carService = new CarService();

        public void OnGet(string? req)
        {
            Request = req;
            using (ApplicationContext db = new ApplicationContext())
            {
                Car[] carArray = db.Cars.ToArray();
                ResCars = (from car in carArray where carService.CheckCar(Request ?? "", car) select car).ToArray();
            }
        }
    }
}
