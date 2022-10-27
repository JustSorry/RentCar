using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DAL.Data;
using RentCar.DAL.Models;
using System.Collections;
using DAL.Contracts;

namespace RentCar.DAL.Repositories
{
	public class ReposCar : IReposCar<Car>
	{
		private ApplicationContext db = new ApplicationContext();

		async Task IReposCar<Car>.Create(Car car)
		{
			db.Add(car);
			await db.SaveChangesAsync();
		}

		void IReposCar<Car>.Delete(Car car)
		{
			db.Cars.Remove(car);
			db.SaveChangesAsync();
		}

        async Task IReposCar<Car>.Update(Car car)
        {
            db.Update(car);
            await db.SaveChangesAsync();
        }

        IEnumerable <Car> IReposCar<Car>.GetAll()
		{
			List<Car> allCars = db.Cars.ToList();
			return allCars;
		}
	}
}
