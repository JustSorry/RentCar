using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages;

public class CatalogModel : PageModel
{
	private readonly IRentTimeService _timeService;
	public CatalogModel(IRentTimeService rentTimeService) { _timeService = rentTimeService; }

	public async Task OnGet() { await _timeService.CheckRentTimes(await _timeService.GetAllTimes()); }
}