using DAL.Models;

namespace DAL.Contracts;
public interface IReposNotification
{
	Task<IEnumerable<Notification>> GetAllUserNotes(string userId);
}

