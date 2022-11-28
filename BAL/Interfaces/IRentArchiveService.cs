using DAL.Models;

namespace BAL.Interfaces
{
	public interface IRentArchiveService
	{
		Task Add(RentArchive rt);
		IEnumerable<RentArchive> GetArchive();
		IEnumerable<RentArchive> GetUserHistory(string userId);
		Task Extend(string UserId, DateTime newEndDate);
		Task Update(RentArchive ra);
		Task EditEndTimeAfterDelete(RentTime rt);

	}
}
