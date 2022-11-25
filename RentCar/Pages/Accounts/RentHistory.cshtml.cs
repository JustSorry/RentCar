using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Accounts;

public class RentHistoryModel : PageModel
{
	private readonly IRentArchiveService _archiveService;
	private readonly ICarService _carService;
	public List<RentArchive> rentHistory = new List<RentArchive>();
	public Dictionary<RentArchive, Car> fullUserHistory = new Dictionary<RentArchive, Car>();

	public RentHistoryModel(IRentArchiveService archiveService, ICarService carService)
	{
		_archiveService = archiveService;
		_carService = carService;
	}

	public async Task OnGet(string UserId)
	{
		rentHistory = _archiveService.GetUserHistory(UserId).ToList();
		foreach (var rent in rentHistory)
		{
			fullUserHistory.Add(rent, await _carService.GetCar(rent.CarId));
		}
		if (fullUserHistory.Count == 0) { Response.Redirect("/Error?error=user-history-is-empty"); }
	}
}

