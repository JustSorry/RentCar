using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using RentCar.Models;
using Microsoft.AspNetCore.Authorization;

namespace RentCar.Pages.Moderator
{
    [Authorize(Roles = "moderator")]
    public class EditRoleModel : PageModel
    {
        public List<UserRoleModel> Users { get; set; } = new List<UserRoleModel>();     // for adding newUserModel (string #30)
        UserManager<User> userManager;
        public EditRoleModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<PageResult> OnGet()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach(User user in db.Users.ToList())
                {
                    var identityRoles = await userManager.GetRolesAsync(user);
                    UserRoleModel newUserRole = new UserRoleModel() { currentUser = user, userRole = identityRoles.ToList() };
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

    }
}
