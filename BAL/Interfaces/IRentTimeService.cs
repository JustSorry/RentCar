using DAL.Models;

namespace BAL.Interfaces
{
    public interface IRentTimeService
	{
        Task<IEnumerable<RentTime>> GetAllTimes();
        Task<RentTime> GetRentingTime(string userId);
        Task DeleteRentCar(User user);
        Task Update(RentTime rentTime);
        Task Edit(RentTime rentTime, User user);
        Task CheckRentTimes(IEnumerable<RentTime> allRT);
    }
}
