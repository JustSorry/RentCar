using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Accounts
{
    public class RegModel : PageModel
    {
        private readonly IUserService _userService;
        public string Username { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;

        public RegModel(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Username = Request.Form["username"];
            Email = Request.Form["email"];

            var result = await _userService.Register(
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
    

}