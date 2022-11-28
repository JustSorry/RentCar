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
            await _archiveService.EditEndTimeAfterDelete(user.RentTime.First());
			user.RentTime = null;
            await _repositoryUser.Update(user);
        }

        public async Task Extend(User user, DateTime newEndDate)
        {
            user.RentTime.First().RentEndTime = newEndDate;
            await _repositoryUser.Update(user);
            await _archiveService.Extend(user.Id, newEndDate);
        }

        public async Task CheckRentTimes(IEnumerable<RentTime> allRT)
        {
            foreach (var time in allRT)
            {
                if (time.RentEndTime < DateTime.Now)
                {
					await DeleteRentCar(await _repositoryUser.GetUser(time.UserId));
				}
            }
            List<RentArchive> allRA = _archiveService.GetArchive().ToList();
            foreach (var archiveItem in allRA) 
            {
                if(archiveItem.RentStatus != "ended")
                {
					if (archiveItem.RentStartDate <= DateTime.Today && archiveItem.RentEndDate >= DateTime.Today)
					{
						archiveItem.RentStatus = "active";
					}
					else if (archiveItem.RentEndDate < DateTime.Today) { archiveItem.RentStatus = "ended"; }
					else archiveItem.RentStatus = "non-active";
					await _archiveService.Update(archiveItem);
				}
            }
        }
    }
}
