using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Accounts;
public class CarsCompareModel : PageModel
{
    private IUserService _userService;
    private ICompareService _compareService;
    private ICarService _carService;
    private Car takedCar;
    public Car[]? comCars;
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
        if (currentUser.UserCompare.CompareCar1ID == null && currentUser.UserCompare.CompareCar2ID == null) { Response.Redirect("/Error?error=com-is-empty"); }
        else { comCars = new Car[] { await _carService.GetCar(currentUser.UserCompare.CompareCar1ID), await _carService.GetCar(currentUser.UserCompare.CompareCar2ID) }; }
    }

    public async Task<IActionResult> OnPost(string userId, int carId, bool DelComBtnPushed, bool DelFromComBtnPushed, bool AddToComBtnPushed)
    {
        currentUser = await _userService.GetUser(userId);
        takedCar = await _carService.GetCar(carId);
        if(DelComBtnPushed ) 
        {
            await _compareService.DeleteCompare(currentUser);
		}
        if(DelFromComBtnPushed ) 
        {
            await _compareService.DeleteFromCompare(currentUser, takedCar);
		}
		return RedirectToPage("/Catalog");   
    }
}