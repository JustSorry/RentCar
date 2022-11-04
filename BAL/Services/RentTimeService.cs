using BAL.Interfaces;
using DAL.Models;
using DAL.Contracts;
using DAL.Repositories;

namespace BAL.Services
{
    public class RentTimeService : IRentTimeService
	{
        public readonly IReposRentTime _repositoryRentTime;
        public readonly IReposUser _repositoryUser;
        
        public RentTimeService(IReposRentTime reposRentTime, IReposUser reposUser)
        {
            _repositoryRentTime = reposRentTime;
            _repositoryUser = reposUser;
        }

        public IEnumerable<RentTime> GetAllTimes()
        {
            return _repositoryRentTime.GetAllRentTimes();
        }

        public async Task<RentTime> GetRentingTime(string userId)
        {
            return await _repositoryRentTime.GetRentTime(userId);
        }

        public async Task Update(RentTime rentTime)
        {
            await _repositoryRentTime.Update(rentTime);
        }
        
        public async Task DeleteRentCar(RentTime rentTime, User user)
        {
            user.RentTime = null;
            await _repositoryUser.Update(user);
        }
    }
}
