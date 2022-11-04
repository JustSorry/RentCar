using BAL.Services;
using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Moderator;

public class InitRolesModel : PageModel
{
    private IRoleService _roleService;
    private IUserService _userService;

    public InitRolesModel(IRoleService roleService, IUserService userService)
    {
        _roleService = roleService;
        _userService = userService;
    }

    public async Task<IActionResult> OnGet()
    {
        if(_userService.GetAllUsers().Count() == 1)
        {
            await _roleService.Create(new string[] { "moderator", "admin" });
            await _userService.AddRole(await _userService.GetUser(User.Claims.FirstOrDefault().Value), "moderator");
        }
        return RedirectToPage("/Index");
    }
}
