using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages;
public class ChooseRentDateModel : PageModel
{
    private readonly ICarService _carService;
    private readonly IUserService _userService;
    private readonly IRentTimeService _rentTimeService;
    public IEnumerable<RentTime> allTimes;
    public Car takedCar;
    public User currentUser;

    public ChooseRentDateModel(ICarService carService, IUserService userService, IRentTimeService rentTimeService)
    {
        _carService = carService;
        _userService = userService;
        _rentTimeService = rentTimeService;
    }

    public async Task OnGet(string currentUserId, int takedCarId)
    {
        allTimes = await _rentTimeService.GetAllTimes();
        currentUser = await _userService.GetUser(currentUserId);
        takedCar = await _carService.GetCar(takedCarId);
        
    }

    public async Task OnPostAsync(DateTime rentStartDate, DateTime rentEndDate, string currentUserId, int takedCarId)
    {
        
        allTimes = await _rentTimeService.GetAllTimes();
        takedCar = await _carService.GetCar(takedCarId);
        currentUser = await _userService.GetUser(currentUserId);
        switch (await _carService.RentCar(rentStartDate, rentEndDate, takedCar, currentUser))
        {
            case "error-end-date-uncorrect":
                Response.Redirect("/Error?error=error-end-date-uncorrect");
                break;
            case "success":
                await _userService.Update(currentUser);
                Response.Redirect("/Index");
                break;
            case "error-havecar":
                Response.Redirect("/Error?error=error-havecar");
                break;
            case "error-car-unavailable":
                Response.Redirect("/Error?error=error-car-unavb");
                break;
        }
    }
}

