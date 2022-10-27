using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using RentCar.Models;
using Microsoft.AspNetCore.Authorization;

namespace RentCar.Pages.Moderator
{
    [Authorize(policy:"moderRights")]
    public class GiveRoleModel : PageModel
    {
        UserManager<User> userManager;
        public List<UserRoleModel> Users { get; set; } = new List<UserRoleModel>();     // for adding newUserModel (string #23)

        public async Task<PageResult> OnGet()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach(User user in db.Users.ToList())
                {
                    var userRoles = await userManager.GetRolesAsync(user);
                    UserRoleModel newUserRole = new UserRoleModel() { currentUser = user, userRole = userRoles.ToList() };
                    Users.Add(newUserRole);
                }
            }
            return Page();
        }

        public class UserRoleModel
        {
            public User currentUser { get; set; }
            public List <string> userRole { get; set; }
        }

        public GiveRoleModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> OnPost(string adminRoleBtn, string id)
        {
            User user = await userManager.FindByIdAsync(id);
            switch (adminRoleBtn)
            {
                case "giveAdmin":
                    await userManager.AddToRoleAsync(user, "admin");
                    break;
                case "removeAdmin":
                    await userManager.RemoveFromRoleAsync(user, "admin");
                    break;
            }
            return RedirectToPage("/Moderator/GiveRole");

        }
    }
}
