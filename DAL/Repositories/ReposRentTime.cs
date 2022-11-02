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
	}
}
