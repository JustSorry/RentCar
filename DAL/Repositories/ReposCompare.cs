using DAL.Models;
using DAL.Contracts;
using DAL.Data;

namespace DAL.Repositories
{
    public class ReposCompare : IReposCompare
    {
        private ApplicationContext db = new ApplicationContext();

        public async Task NewCompare(Compare compare)
        {
			db.Add(compare);
			await db.SaveChangesAsync();
		}

        public async Task AddToCompare(User user, Car car)
        {
            user.UserCompare.CompareCar2ID = car.Id;
        }

        public async Task DeleteFromCompare(User user, Car car)
        {
            if(user.UserCompare.CompareCar1ID == car.Id) { user.UserCompare.CompareCar1ID = null; }
            if(user.UserCompare.CompareCar2ID == car.Id) { user.UserCompare.CompareCar2ID = null; }
            await db.SaveChangesAsync();
        }

        public async Task DeleteCompare(Compare compare)
        {
            compare.CompareCar1ID = null;
            compare.CompareCar2ID= null;
            await db.SaveChangesAsync();
        }

        public IEnumerable<Compare> GetAll()
        {
            IEnumerable<Compare> result = db.Compare.ToList();
            return result;
        }

        public async Task<Compare> GetCompare(string userId, int carId)
        {
            List<Compare> result = db.Compare.ToList();
            foreach(var item in result) 
            {
                if ((item.CompareCar1ID == carId || item.CompareCar2ID == carId)&item.UserId == userId)
                {
                    return item;
                }
            }
            return null;
        }

        public async Task<Compare> GetUserCompare(string userId)
        {
            List<Compare> result = db.Compare.ToList();
            foreach (var item in result) 
            {
                if(item.UserId == userId) { return item; }
            }
            return null;
        }

        public async Task Update(Compare compare)
        {
			db.Update(compare);
			db.SaveChanges();
		}
	}
}
