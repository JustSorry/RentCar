using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Models;
using BAL.Interfaces;
using DAL.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using BAL.Services;
using Microsoft.AspNetCore.Identity;

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
