using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using RentCar.Models;

namespace RentCar.Pages.Accounts
{
    public class RegViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string? Username { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not compare")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password")]
        public string? PasswordConfirm { get; set; }
    }

    public class RegModel : PageModel
    {
        [BindProperty]
        public RegViewModel model { get; set; } = new RegViewModel();
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public RegModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        private async Task<IActionResult> Register()
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Username};

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToPage("/Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Page();

        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            return await Register();
        }
    }
}