using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
	public interface IRentTimeService
	{
        IEnumerable<RentTime> GetAllTimes();
        Task<RentTime> GetRentingTime(string userId);
        Task DeleteRentCar(RentTime rentTime, User user);
        Task Update(RentTime rentTime);
    }
}
