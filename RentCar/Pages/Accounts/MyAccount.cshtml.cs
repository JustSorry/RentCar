using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Models;
using DAL.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using BAL.Services;
using Microsoft.AspNetCore.Identity;

namespace RentCar.Pages
{
    public class MyAccountModel : PageModel
    {
        private readonly UserService _userService;
        public MyAccountModel(UserManager<User> userManager, SignInManager<User> signInManager) {_userService = new(userManager, signInManager);}
            
        public User? CurrentUser { get; set; }

        public async Task OnGet(string? Nickname)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User[] usersArray = db.Users.ToArray();
                CurrentUser =await _userService.GetUser(usersArray, Nickname);
            }
        }
    }
}
