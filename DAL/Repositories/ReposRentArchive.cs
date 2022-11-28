using DAL.Contracts;
using DAL.Data;
using DAL.Models;

namespace DAL.Repositories;
public class ReposRentArchive : IReposRentArchive
{
	ApplicationContext db = new ApplicationContext();
	public async Task Add(RentArchive ra)
	{
		db.RentArchive.Add(ra);
		db.SaveChanges();
	}

	public IEnumerable<RentArchive> GetArchive()
	{
		List<RentArchive>archive = db.RentArchive.ToList();
		return archive;
	}

	public async Task Update(RentArchive ra)
	{
		db.RentArchive.Update(ra);
		await db.SaveChangesAsync();
	}
}
