using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Admin;
public class ArchiveMngModel : PageModel
{
	private readonly IRentArchiveService _archiveService;

	public List<RentArchive> archive = new List<RentArchive>();
    
    public ArchiveMngModel(IRentArchiveService archiveService)
    {
        _archiveService  = archiveService;
    }
    public void OnGet()
    {
        archive = _archiveService.GetArchive().ToList();
    }
}
