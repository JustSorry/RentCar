using BAL.Interfaces;
using DAL.Contracts;
using DAL.Models;

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

        public async Task<IEnumerable<RentTime>> GetAllTimes()
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

        public async Task CheckRentTimes(IEnumerable<RentTime> allRT)
        {
            foreach(var time in allRT)
            {
                if (time.RentEndTime < DateTime.Now)
                {
                    await DeleteRentCar(time, await _repositoryUser.GetUser(time.UserId));
                }
            }
        }
    }
}
