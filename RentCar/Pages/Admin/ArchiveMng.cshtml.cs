using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Admin;
public class ArchiveMngModel : PageModel
{
	private readonly IRentArchiveService _archiveService;
	private readonly ICarService _carService;

	public List<RentArchive> rentArchive = new List<RentArchive>();
	public Dictionary<RentArchive, Car> fullArchive = new Dictionary<RentArchive, Car>();

	public ArchiveMngModel(IRentArchiveService archiveService, ICarService carService)
	{
		_archiveService = archiveService;
		_carService = carService;
	}
	public async Task OnGet()
	{
		rentArchive = _archiveService.GetArchive().ToList();
		foreach (var arch in rentArchive)
		{
			fullArchive.Add(arch, await _carService.GetCar(arch.CarId));
		}
	}
}
