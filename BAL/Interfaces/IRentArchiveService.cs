using DAL.Models;

namespace BAL.Interfaces
{
	public interface IRentArchiveService
	{
		Task Add(RentTime rt);
		IEnumerable<RentArchive> GetArchive();
		IEnumerable<RentArchive> GetUserHistory(string userId);
	}
}
