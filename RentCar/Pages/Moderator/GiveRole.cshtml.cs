using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using DAL.Models;
using DAL.Data;
using BAL.Services;
using Microsoft.AspNetCore.Authorization;

namespace RentCar.Pages.Moderator
{
    [Authorize(policy:"moderRights")]
    public class GiveRoleModel : PageModel
    {
        private readonly UserService _userService;
        public List<UserRoleModel> Users { get; set; } = new();
        public string Req { get; set; } = "";

        public class UserRoleModel
        {
            public User currentUser { get; set; }
            public List<string> userRole { get; set; }
        }

        public GiveRoleModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userService = new(userManager, signInManager);
        }


        public async Task<IActionResult> OnGet()
        {
            foreach (User user in _userService.GetAllUsers())
            {
                var userRoles = _userService.GetRoles(user);
                UserRoleModel newUserRole = new UserRoleModel() { currentUser = user, userRole = userRoles.ToList() };
                Users.Add(newUserRole);
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(string adminRoleBtn, string id)
        {
            User user = await _userService.GetUser(id);
            switch (adminRoleBtn)
            {
                case "giveAdmin":
                    await _userService.AddRole(user, "admin");
                    break;
                case "removeAdmin":
                    await _userService.RemoveRole(user, "admin");
                    break;
            }
            return RedirectToPage("/Moderator/GiveRole");
        }
    }
}












        //UserManager<User> userManager;
        //public List<UserRoleModel> Users { get; set; } = new List<UserRoleModel>();     // for adding newUserModel 

//public async Task<PageResult> OnGet()
//{
//    using (ApplicationContext db = new ApplicationContext())
//    {
//        foreach(User user in db.Users.ToList())
//        {
//            var userRoles = await userManager.GetRolesAsync(user);
//            UserRoleModel newUserRole = new UserRoleModel() { currentUser = user, userRole = userRoles.ToList() };
//            Users.Add(newUserRole);
//        }
//    }
//    return Page();
//}
