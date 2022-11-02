using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Models;
using DAL.Data;
using BAL.Services;
using BAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace RentCar.Pages
{
    public class CarPageModel : PageModel
    {
        private ICarService _carService;
        private IUserService _userService;
        public Car takedCar;
        public User actualUser;

        public CarPageModel(IUserService userService, ICarService carService)
        {
            _userService = userService;
            _carService = carService;
        }
        public async Task OnGet(int Id)
        {
            takedCar =await _carService.GetCar(Id);
        }


        public async Task<IActionResult> OnPost(int rentTermButton, int carId)
        {
            actualUser = await _userService.GetUser(User.Claims.First().Value);
            takedCar = await _carService.GetCar(carId);
            bool isAcceced = _carService.RentCar(DateTime.Now, DateTime.Now.AddDays(rentTermButton), takedCar, actualUser);
            if (isAcceced)
            {
                await _userService.Update(actualUser);
                return RedirectToPage("/Index");
            }
            else return RedirectToPage("/Error");
            //_userService.GetUser(User.Claims.FirstOrDefault().Value)
        }
    }
}
