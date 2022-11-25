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
		List<RentArchive> userHistory= new List<RentArchive>();
		foreach(var note in _reposArchive.GetArchive())
		{
			if (note.UserId == userId) {userHistory.Add(note);}
		}
		return userHistory;
	}

	public async Task Extend(int archiveItemId, DateTime newEndDate)
	{
		foreach(var item in _reposArchive.GetArchive())
		{
			if(item.Id == archiveItemId)
			{
				item.RentEndDate = newEndDate;
				_reposArchive.Update(item);
			}
		}
		
	}
}

