using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace RentCar.Pages.Accounts
{
    public class SignInModel : PageModel
    {
        private readonly IUserService _userService;

        public SignInModel(IUserService userManager)
        {
            _userService = userManager;
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
    }
}
