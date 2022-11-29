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
        public readonly INotificationService _noteService;
        
        public RentTimeService(IReposRentTime reposRentTime, IReposUser reposUser, IRentArchiveService archiveService, INotificationService noteService)
        {
            _repositoryRentTime = reposRentTime;
            _repositoryUser = reposUser;
            _archiveService = archiveService;
            _noteService = noteService;
        }

        public async Task<IEnumerable<RentTime>> GetAllTimes()
        {
            return _repositoryRentTime.GetAllRentTimes();
        }

        public async Task<RentTime> GetRentingTime(string userId)
        {
            return await _repositoryRentTime.GetRentTime(userId);
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
                    await _noteService.Add(time.CarId, time.RentStartTime, time.UserId, "ended");
				}
            }
            foreach (var archiveItem in _archiveService.GetArchive().ToList()) 
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
