using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCar.Models;

namespace RentCar.Pages.Moderator
{
    public class InitRolesModel : PageModel
    {
        private RoleManager<IdentityRole> roleManager;  
        private UserManager<User> userManager;
        public InitRolesModel(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            using (ApplicationContext db = new())
            {
                if (User.Identity.IsAuthenticated && db.Users.Count() == 1)
                {
                    await roleManager.CreateAsync(new IdentityRole("admin"));
                    await roleManager.CreateAsync(new IdentityRole("moderator"));
                    await userManager.AddToRolesAsync(await userManager.FindByNameAsync(User.Identity.Name), new List<string>() { "moderator", "admin" });
                }

            }
            return RedirectToPage("/Index");
        }
    }
}
