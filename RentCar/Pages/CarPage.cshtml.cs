using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Models;
using DAL.Data;
using BAL.Services;
using Microsoft.AspNetCore.Identity;

namespace RentCar.Pages
{
    public class CarPageModel : PageModel
    {
        CarService _carService = new CarService();
        UserService _userService;
        public CarPageModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userService = new UserService(userManager, signInManager); 
        }
        public Car takedCar;
        public User actualUser;
        DateTime RentStartDate { get; set; }
        DateTime RentEndDate { get; set; }
        public async Task OnGet(int Id)
        { 
            using (ApplicationContext db = new ApplicationContext())
            {
                Car[] allCars = db.Cars.ToArray();
                takedCar = await _carService.GetCar(allCars, Id);
            }
        }

        public async Task OnPost(int rentTermButton, int carId)
        {
            actualUser = await _userService.GetUser(User.Claims.First().Value);
            Car[] allCars = new Car[0];
            using(ApplicationContext db = new ApplicationContext()) { allCars = db.Cars.ToArray(); }
            takedCar = await _carService.GetCar(allCars, carId);
            RentStartDate = DateTime.Now;
            if(rentTermButton == 1) RentEndDate = RentStartDate.AddDays(1);
            if(rentTermButton == 7) RentEndDate = RentStartDate.AddDays(7);
            _carService.RentCar(RentStartDate, RentEndDate, takedCar, actualUser);
            await _userService.Update(actualUser);
           //_userService.GetUser(User.Claims.FirstOrDefault().Value)
        }
    }
}
