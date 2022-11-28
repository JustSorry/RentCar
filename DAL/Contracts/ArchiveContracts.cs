using DAL.Models;

namespace DAL.Contracts;
public interface IReposRentArchive
{
	Task Add(RentArchive ra);
	IEnumerable<RentArchive> GetArchive();
	Task Update(RentArchive ra);
}
