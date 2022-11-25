using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Accounts;

public class EditRentTimeModel : PageModel
{
    private readonly IUserService _userService;
    private readonly IRentTimeService _timeService;
    private readonly IRentArchiveService _archiveService;
    private readonly ICarService _carService;

    public User currentUser;
    public Car takedCar;

    public EditRentTimeModel(IUserService userService, IRentTimeService rentTimeService, IRentArchiveService archiveService, ICarService carService)
    {
        _userService = userService;
        _timeService = rentTimeService;
        _archiveService = archiveService;
        _carService = carService;
    }

    public async Task OnGet(string userId, int carId)
    {
        currentUser = await _userService.GetUser(userId);
        takedCar = await _carService.GetCar(carId);
    }

    public async Task OnPost(bool editBtnPushed, string userId, int carId, DateTime newEndDate)
    {
		takedCar = await _carService.GetCar(carId);
		currentUser = await _userService.GetUser(userId);
        if (editBtnPushed)
        {
            await _timeService.Extend(currentUser, newEndDate);
        }
    }
}

