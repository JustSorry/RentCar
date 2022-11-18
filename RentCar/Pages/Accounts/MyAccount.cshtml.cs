using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages
{
    public class MyAccountModel : PageModel
    {
        private readonly IUserService _userService;
        public MyAccountModel(IUserService userService) 
        {
            _userService = userService;
        }
            
        public User? CurrentUser { get; set; }

        public async Task OnGet(string? Nickname)
        {
            CurrentUser =await _userService.GetUser(Nickname);
        }
    }
}
