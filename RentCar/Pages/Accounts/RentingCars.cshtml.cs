using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Accounts
{
    public class RentingCarsModel : PageModel
    {
        private readonly IRentTimeService _timeService;
        private readonly IUserService _userService;
        private readonly ICarService _carService;
        public RentingCarsModel(IUserService userService, ICarService carService, IRentTimeService timeService ) 
        { 
            _userService = userService;
            _carService = carService;
            _timeService = timeService; 
        }

        private User currentUser;
        public RentTime UserRent;
        public Car rentingCar;
        public async Task OnGet(string UserId)
        {
            currentUser = await _userService.GetUser(User.Claims.First().Value);
            UserRent = await _timeService.GetRentingTime(UserId);                                                   
            if (UserRent != null)
            {
                if (DateTime.Now > UserRent.RentEndTime) 
                {
                    await _timeService.DeleteRentCar(UserRent, currentUser);
                    Response.Redirect($"/Accounts/RentingCars?UserId={UserId}");
                }
                rentingCar = await _carService.GetCar(UserRent.CarId);
            }
        }

        public async Task OnPost(bool deleteRent)
        {
            currentUser = await _userService.GetUser(User.Claims.First().Value);
            UserRent = await _timeService.GetRentingTime(currentUser.Id);
            if (deleteRent)
            {
                await _timeService.DeleteRentCar(UserRent, currentUser);
            }
            RedirectToPage("/Catalog");
        }
    }
}
