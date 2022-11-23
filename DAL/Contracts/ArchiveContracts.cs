using DAL.Models;

namespace DAL.Contracts;
public interface IReposRentArchive
{
	Task Add(RentTime rt);
	IEnumerable<RentArchive> GetArchive();
}
