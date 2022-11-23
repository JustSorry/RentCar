using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages
{
    public class MyAccountModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRentTimeService _timeService;
        public MyAccountModel(IUserService userService, IRentTimeService timeService) 
        {
            _userService = userService;
            _timeService = timeService;
        }
            
        public User? CurrentUser { get; set; }

        public async Task OnGet(string Nickname)
        {
			await _timeService.CheckRentTimes(await _timeService.GetAllTimes());
            CurrentUser = await _userService.GetUser(Nickname);
        }
    }
}
