using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using RentCar.Models;


namespace RentCar.Pages.Accounts
{
    public class SignInViewModel
    {
        [Required]
        [Display(Name = "Your Username")]
        public string? Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Your password")]
        public string? Password { get; set; }

        [Display(Name = "Do I remember your password?")]
        public bool RememberMe { get; set; }

    }
    public class SignInModel : PageModel
    {
        [BindProperty]
        public SignInViewModel model { get; set; } = new();
        private readonly SignInManager<User> _signInManager;
        public SignInModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {

        }

        private async Task<IActionResult> Login()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError("", "Your username or password is wrong");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            return await Login();
        }
    }
}
