using DAL.Models;

namespace DAL.Contracts;

public interface IReposRentTime
{
	IEnumerable<RentTime> GetAllRentTimes();
	Task<RentTime> GetRentTime(string id);
}
