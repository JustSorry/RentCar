using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Accounts
{
    public class CarsCompareModel : PageModel
    {
        private IUserService _userService;
        private ICompareService _compareService;
        private ICarService _carService;
        public IEnumerable<Compare> allUserCompares = new List<Compare>();
        public IEnumerable<Car> comCars;
		public User currentUser;

		public CarsCompareModel(IUserService userService, ICompareService compareService, ICarService carService) 
        {
            _userService = userService;
            _compareService= compareService;
            _carService = carService;
        }

        public async Task OnGet(string UserId)
        {
            currentUser = await _userService.GetUser(UserId);
            allUserCompares = _compareService.GetAll();
            if (currentUser.UserCompare.CompareCar1ID == null && currentUser.UserCompare.CompareCar2ID == null) { Response.Redirect("/Error?error=com-is-empty"); }
            else { comCars = new List<Car> { await _carService.GetCar(currentUser.UserCompare.CompareCar1ID), await _carService.GetCar(currentUser.UserCompare.CompareCar2ID) }; }  
        }

        public async Task OnPost(User currentUser, Car car, bool DelComBtnPushed, bool DelCarFromComBtnPushed, bool AddToComBtnPushed)
        {
            if(DelComBtnPushed ) {await _compareService.DeleteCompare(currentUser); }
            if(DelCarFromComBtnPushed ) { await _compareService.DeleteFromCompare(currentUser, car); }
            if(AddToComBtnPushed) { await _compareService.AddToCompare(currentUser, car); }   
        }
    }
}
