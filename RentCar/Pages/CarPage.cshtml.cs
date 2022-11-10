using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public async Task OnPost(int carId, bool rentBtnPushed)
        {
            if(rentBtnPushed)
            {
                
                takedCar = await _carService.GetCar(carId);
                if (User.Identity.IsAuthenticated)
                {
                    actualUser = await _userService.GetUser(User.Claims.First().Value);
                    Response.Redirect($"/ChooseRentDate?currentUserId={actualUser.Id}&takedCarId={takedCar.Id}");
                }
                else Response.Redirect("/Accounts/Sign-in");
                
            }
            
        }
    }
}
