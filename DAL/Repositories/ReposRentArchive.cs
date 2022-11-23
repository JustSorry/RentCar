using DAL.Contracts;
using DAL.Data;
using DAL.Models;

namespace DAL.Repositories;
public class ReposRentArchive : IReposRentArchive
{
	ApplicationContext db = new ApplicationContext();
	public async Task Add(RentTime rt)
	{
		db.RentArchive.Add(new RentArchive { CarId = rt.CarId, UserId = rt.UserId, RentStartDate = rt.RentStartTime, RentEndDate = rt.RentEndTime });
		db.SaveChanges();
	}

	public IEnumerable<RentArchive> GetArchive()
	{
		List<RentArchive>archive = db.RentArchive.ToList();
		return archive;
	}
}
