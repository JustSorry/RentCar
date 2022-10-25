using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCar.Models;

namespace RentCar.Pages.Moderator
{
    public class InitRolesModel : PageModel
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        public InitRolesModel(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task OnGet()
        {
            using (ApplicationContext db = new())
            {
                if (db.Users.Count() == 1)
                {
                    var adminRes = _roleManager.CreateAsync(new IdentityRole("admin"));
                    var moderatorRes = _roleManager.CreateAsync(new IdentityRole("moderator"));
                    await _userManager.AddToRolesAsync(await _userManager.FindByNameAsync(User.Identity.Name), new List<string>() { "moderator" });
                }
            }
        }
    }
}
