using DAL.Models;
using BAL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly UserService _userService;

        public LogoutModel(UserManager<User> userManager, SignInManager<User> signInManager) { _userService = new(userManager, signInManager); }
        
        public async Task<IActionResult> OnPost(bool IsLogout)
        {
            if (IsLogout) await _userService.Logout();
            return RedirectToPage("/Index");
        }
    }
}
