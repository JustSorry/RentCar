using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Models;
using BAL.Interfaces;
using BAL.Services;

namespace RentCar.Pages;
public class ChooseRentDateModel : PageModel
{
    private readonly ICarService _carService;
    private readonly IUserService _userService;
    public Car takedCar;
    public User currentUser;

    public ChooseRentDateModel(ICarService carService, IUserService userService)
    {
        _carService = carService;
        _userService = userService;
    }

    public async Task OnGet(string currentUserId, int takedCarId)
    {
        currentUser = await _userService.GetUser(currentUserId);
        takedCar = await _carService.GetCar(takedCarId);
    }

    public async Task OnPostAsync(DateTime rentStartDate, DateTime rentEndDate, string currentUserId, int takedCarId)
    {
        takedCar = await _carService.GetCar(takedCarId);
        currentUser = await _userService.GetUser(currentUserId);
        bool isSucceced = _carService.RentCar(rentStartDate, rentEndDate, takedCar, currentUser);
        if (isSucceced)
        {
            await _userService.Update(currentUser);
        }
        Response.Redirect("/Index");
    }
}

