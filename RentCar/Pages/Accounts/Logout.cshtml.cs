using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly IUserService _userService;

        public LogoutModel(IUserService userService) 
        { 
            _userService = userService; 
        }

        public async Task<IActionResult> OnPost(bool IsLogout)
        {
            if (IsLogout) await _userService.Logout();
            return RedirectToPage("/Index");
        }
    }
}
