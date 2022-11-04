using DAL.Contracts;
using DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DAL.Data;

namespace DAL.Repositories
{
	public class ReposRentTime : IReposRentTime
	{
        private ApplicationContext db = new ApplicationContext();
        public IEnumerable<RentTime> GetAllRentTimes()
		{
			return db.RentTime.ToList();
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
