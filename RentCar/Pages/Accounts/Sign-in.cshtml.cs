using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using DAL.Models;
using BAL.Services;


namespace RentCar.Pages.Accounts
{
    public class SignInModel : PageModel
    {
        private readonly UserService _userService;
        public string Username { get; set; } = "";

        public SignInModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userService = new(userManager, signInManager);
        }

        public async Task<IActionResult> OnPostAsync(bool remember)
        {
            var result = await _userService.Login(Request.Form["username"], Request.Form["password"], remember);

            if (result.Succeeded)
            {
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError("", "");
            return Page();
        }
        //[BindProperty]
        //public SignInViewModel model { get; set; } = new();
        //private readonly SignInManager<User> _signInManager;
        //public SignInModel(SignInManager<User> signInManager)
        //{
        //    _signInManager = signInManager;
        //}

        //private async Task<IActionResult> Login()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
        //        if (result.Succeeded)
        //            return RedirectToPage("/Index");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Your username or password is wrong");
        //    }
        //    return Page();
        //}

        //public async Task<IActionResult> OnPost()
        //{
        //    return await Login();
        //}
    }
}
