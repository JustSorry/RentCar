using DAL.Contracts;
using DAL.Data;
using DAL.Models;

namespace DAL.Repositories
{
    public class ReposRentTime : IReposRentTime
	{
        private ApplicationContext db = new ApplicationContext();
        public IEnumerable<RentTime> GetAllRentTimes()
		{
            List<RentTime> rentTimes = db.RentTime.ToList();
			return rentTimes;
		}

		public async Task<RentTime> GetRentTime(string id)
		{
			return db.RentTime.Find(id);
		}

        public async Task RentTimeDelete(RentTime rentTime)
        {
            db.RentTime.Remove(rentTime);
            await db.SaveChangesAsync();
        }

        public async Task Update(RentTime rentTime)
        {
            db.Update(rentTime);
            await db.SaveChangesAsync();
        }
    }
}
