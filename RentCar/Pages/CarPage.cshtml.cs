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
        private ICompareService _compareService;
        public Car takedCar;
        public User actualUser;

        public CarPageModel(IUserService userService, ICarService carService, ICompareService compareService)
        {
            _userService = userService;
            _carService = carService;
            _compareService = compareService;
        }

        public async Task OnGet(int Id)
        {
            takedCar =await _carService.GetCar(Id);
        }

        public async Task OnPost(int carId, bool rentBtnPushed, bool compareBtnPushed)
        {
            takedCar = await _carService.GetCar(carId);
            actualUser = await _userService.GetUser(User.Claims.First().Value);
            if (rentBtnPushed)
            {
                if (User.Identity.IsAuthenticated) {Response.Redirect($"/ChooseRentDate?currentUserId={actualUser.Id}&takedCarId={takedCar.Id}");}
                else Response.Redirect("/Accounts/Sign-in");
            }
            if(compareBtnPushed)
            {
                string res = await _compareService.AddToCompare(actualUser, takedCar);
                if(res == "success") 
                {
                    //await _compareService.Update(actualUser.UserCompare);
                    //await _userService.Update(actualUser);
					//return RedirectToPage($"/Accounts/CarsCompare?UserId={actualUser.Id}"); 
					Response.Redirect("/Index"); 
                }
                else { Response.Redirect($"/Error?error={res}"); }
            }
        }
    }
}
