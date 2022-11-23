using BAL.Interfaces;
using DAL.Models;
using DAL.Contracts;

namespace BAL.Services;
public class ArchiveService : IRentArchiveService
{
	private IReposRentArchive _reposArchive;
	public ArchiveService(IReposRentArchive reposRentArchive)
	{
		_reposArchive = reposRentArchive; 
	}
	public async Task Add(RentTime rt)
	{
		await _reposArchive.Add(rt);
	}

	public IEnumerable<RentArchive> GetArchive()
	{
		return _reposArchive.GetArchive();
	}

	public IEnumerable<RentArchive> GetUserHistory(string userId)
	{
		IEnumerable<RentArchive> archive = _reposArchive.GetArchive();
		List<RentArchive> userHistory= new List<RentArchive>();
		foreach(var note in archive) 
		{
			if (note.UserId == userId) {userHistory.Add(note);}
		}
		return userHistory;
	}
}

