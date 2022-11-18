using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Moderator
{
    [Authorize(policy:"moderRights")]
    public class GiveRoleModel : PageModel
    {
        private readonly IUserService _userService;
        public List<UserRoleModel> Users { get; set; } = new();

        public class UserRoleModel
        {
            public User currentUser { get; set; }
            public List<string> userRole { get; set; }
        }

        public GiveRoleModel(IUserService userService)
        {
            _userService = userService;
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
