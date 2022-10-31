using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DAL.Data;
using DAL.Models;
using DAL.Contracts;

namespace DAL.Repositories
{
	public class ReposCar : ICarContracts<Car>
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

        //public async Task<User> GetCar(string id)
        //{
        //    return await _carManager.FindByIdAsync(id);
        //}

        public bool CheckCar(string req, Car car)
        {
            bool isFinded;
            if (car.CarBody == req || car.CountryOfProd == req || car.TypeOfGearbox == req || car.DriveType == req) { return true; }
            return false;
        }

		public async Task<Car> GetCar(Car[] allCars, int id)
		{
			Car finded = null;
			foreach (Car car in allCars)
			{
				if (car.Id == id)
				{
					return car;
				}
			}
			return null;
		}

        public IEnumerable <Car> GetAll()
		{
			List<Car> allCars = db.Cars.ToList();
			return allCars;
		}
	}
}
