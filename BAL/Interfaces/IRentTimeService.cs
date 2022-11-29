using DAL.Models;

namespace BAL.Interfaces
{
    public interface IRentTimeService
	{
        Task<IEnumerable<RentTime>> GetAllTimes();
        Task<RentTime> GetRentingTime(string userId);
        Task DeleteRentCar(User user);
        Task Extend(User user, DateTime newEndDate);
        Task CheckRentTimes(IEnumerable<RentTime> allRT);
    }
}
