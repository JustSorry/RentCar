using BAL.Interfaces;
using DAL.Models;
using DAL.Contracts;
using System.Collections.Generic;

namespace BAL.Services;
public class ArchiveService : IRentArchiveService
{
	private IReposRentArchive _reposArchive;
	public ArchiveService(IReposRentArchive reposRentArchive)
	{
		_reposArchive = reposRentArchive;
	}
	public async Task Add(RentArchive rt)
	{
		await _reposArchive.Add(rt);
	}

	public IEnumerable<RentArchive> GetArchive()
	{
		return _reposArchive.GetArchive();
	}

	public IEnumerable<RentArchive> GetUserHistory(string userId)
	{
		List<RentArchive> userHistory = new List<RentArchive>();
		foreach (var note in _reposArchive.GetArchive())
		{
			if (note.UserId == userId) { userHistory.Add(note); }
		}
		return userHistory;
	}

	public async Task Extend(string userId, DateTime newEndDate)
	{
		foreach (var item in _reposArchive.GetArchive())
		{
			if (item.UserId == userId && (item.RentStatus == "active" || item.RentStatus == "non-active"))
			{
				item.RentEndDate = newEndDate;
				_reposArchive.Update(item);
			}
		}
	}

	public async Task Update(RentArchive ra)
	{
		_reposArchive.Update(ra);
	}

	public async Task EditEndTimeAfterDelete(RentTime rt)
	{
		foreach (RentArchive archiveItem in _reposArchive.GetArchive().ToList())
		{
			if (archiveItem.UserId == rt.UserId && archiveItem.RentStartDate == rt.RentStartTime && archiveItem.RentEndDate == rt.RentEndTime)
			{
				archiveItem.RentEndDate = DateTime.Now;
				archiveItem.RentStatus = "ended";
				await _reposArchive.Update(archiveItem);
			}
		}
	}
}

