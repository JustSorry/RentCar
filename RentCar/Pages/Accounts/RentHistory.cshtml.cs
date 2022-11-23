using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Accounts;

public class RentHistoryModel : PageModel
{
    private IRentArchiveService _archiveService;
    public List<RentArchive> userHistory = new List<RentArchive>();

    public RentHistoryModel(IRentArchiveService archiveService)
    {
        _archiveService = archiveService;
    }
    public void OnGet(string UserId)
    {
        userHistory = _archiveService.GetUserHistory(UserId).ToList();
    }
}

