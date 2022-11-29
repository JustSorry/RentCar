using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Accounts;

public class NotificationsModel : PageModel
{
    private readonly INotificationService _noteService;
    private readonly IUserService _userService;
    public IEnumerable<Notification> allUserNotes;
    public User currentUser;

    public NotificationsModel(INotificationService noteService, IUserService userService)
    {
        _noteService = noteService;
        _userService = userService;
    }

    public async Task OnGet(string userId)
    {
        currentUser = await _userService.GetUser(userId);
        allUserNotes = await _noteService.GetAllUserNotes(userId);
    }

    public async Task OnPost(int noteId, string userId, bool delAllBtnPushed, bool delOneBtnPushed)
    {
        currentUser = await _userService.GetUser(userId);
        if(delAllBtnPushed) 
        {
            await _noteService.DeleteAll(userId);
			RedirectToPage($"/Accounts/MyAccount?Nickname={currentUser.UserName}");
		}
        if(delOneBtnPushed) 
        {
            await _noteService.DeleteOne(userId, noteId);
			RedirectToPage($"/Accounts/MyAccount?Nickname={currentUser.UserName}");
		}
        
    }
}
