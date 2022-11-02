using BAL.Interfaces;
using DAL.Models;
using DAL.Contracts;

namespace BAL.Services
{
    public class RentTimeService : IRentTimeService
	{
        public readonly IReposRentTime _repositoryRentTime;
        
        public RentTimeService(IReposRentTime reposRentTime)
        {
            _repositoryRentTime = reposRentTime;
        }

        public IEnumerable<RentTime> GetAllTimes()
        {
            return _repositoryRentTime.GetAllRentTimes();
        }

        public async Task<RentTime> GetRentingTime(string userId)
        {
            return await _repositoryRentTime.GetRentTime(userId);
        }
    }
}
