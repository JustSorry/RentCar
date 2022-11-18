using DAL.Contracts;
using DAL.Data;
using DAL.Models;

namespace DAL.Repositories
{
	public class ReposCar : IReposCar
	{
		private ApplicationContext db = new ApplicationContext();

		public async Task Create(Car car)
		{
			db.Add(car);
			await db.SaveChangesAsync();
		}

		public void Delete(Car car)
		{
			db.Cars.Remove(car);
			db.SaveChangesAsync();
		}

        public async Task Update(Car car)
        {
            db.Update(car);
            await db.SaveChangesAsync();
        }

        public bool CheckCar(string req, Car car)
        {
            bool isFinded;
            if (car.CarBody == req || car.CountryOfProd == req || car.TypeOfGearbox == req || car.DriveType == req) { return true; }
            return false;
        }

		public async Task<Car> GetCar(int? id)
		{
			return await db.Cars.FindAsync(id);
		}

        public IEnumerable <Car> GetAll()
		{
			List<Car> allCars = db.Cars.ToList();
			return allCars;
		}
	}
}
