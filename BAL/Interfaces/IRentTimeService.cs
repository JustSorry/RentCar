using DAL.Models;

namespace BAL.Interfaces
{
    public interface IRentTimeService
	{
        Task<IEnumerable<RentTime>> GetAllTimes();
        Task<RentTime> GetRentingTime(string userId);
        Task DeleteRentCar(RentTime rentTime, User user);
        Task Update(RentTime rentTime);
        Task CheckRentTimes(IEnumerable<RentTime> allRT);
    }
}
