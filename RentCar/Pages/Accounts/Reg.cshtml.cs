using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using DAL.Models;
using BAL.Services;
using DAL.Data;

namespace RentCar.Pages.Accounts
{
    public class RegModel : PageModel
    {
        private readonly UserService _serviceUser;
        public string Username { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;

        public RegModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _serviceUser = new(userManager, signInManager);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Username = Request.Form["username"];
            Email = Request.Form["email"];

            var result = await _serviceUser.Register(
                Request.Form["username"],
                Request.Form["email"],
                Request.Form["passwordConfirm"],
                Request.Form["password"]
                );

            if (result.Succeeded)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
    //public class RegViewModel
    //{
    //    [Required]
    //    [Display(Name = "Username")]
    //    public string? Username { get; set; }

    //    [Required]
    //    [Display(Name = "Email")]
    //    public string? Email { get; set; }

    //    [Required]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Password")]
    //    public string? Password { get; set; }

    //    [Required]
    //    [Compare("Password", ErrorMessage = "Passwords are not compare")]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Confirm the password")]
    //    public string? PasswordConfirm { get; set; }
    //}
    //private async Task<IActionResult> Register()
    //{
    //    if (ModelState.IsValid)
    //    {
    //        User user = new User { Email = model.Email, UserName = model.Username, Money = 10000000000};

    //        var result = await _serviceUser.Create(user, model.Password);

    //        if (result.Succeeded)
    //        {
    //            await _signInManager.SignInAsync(user, false);
    //            return RedirectToPage("/Index");
    //        }
    //        else
    //        {
    //            foreach (var error in result.Errors)
    //            {
    //                ModelState.AddModelError(string.Empty, error.Description);
    //            }
    //        }
    //    }
    //    return Page();

    //}

}