using BAL.Interfaces;
using DAL.Contracts;
using DAL.Models;

namespace BAL.Services
{
    public class RentTimeService : IRentTimeService
	{
        public readonly IReposRentTime _repositoryRentTime;
        public readonly IReposUser _repositoryUser;
        public readonly IRentArchiveService _archiveService;
        
        public RentTimeService(IReposRentTime reposRentTime, IReposUser reposUser, IRentArchiveService archiveService)
        {
            _repositoryRentTime = reposRentTime;
            _repositoryUser = reposUser;
            _archiveService = archiveService;
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
        
        public async Task DeleteRentCar(User user)
        {
            user.RentTime = null;
            await _repositoryUser.Update(user);
        }

        public async Task Extend(User user, DateTime newEndDate)
        {
            user.RentTime.First().RentEndTime = newEndDate;
            await _repositoryUser.Update(user);
        }

        public async Task CheckRentTimes(IEnumerable<RentTime> allRT)
        {
            foreach (var time in allRT)
            {
                if (time.RentEndTime < DateTime.Now)
                {
					await _archiveService.Add(new RentTime { UserId = time.UserId, CarId = time.CarId, RentEndTime = time.RentEndTime, RentStartTime = time.RentStartTime });
					await DeleteRentCar(await _repositoryUser.GetUser(time.UserId));
				}
            }
        }
    }
}
