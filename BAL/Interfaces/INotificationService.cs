using DAL.Models;

namespace BAL.Interfaces;

public interface INotificationService
{
	Task Add(int carId, DateTime startDate, string userId, string message);
	Task DeleteOne(string userId, int noteId);
	Task DeleteAll(string userId);
	Task<IEnumerable<Notification>> GetAllUserNotes(string userId);

}
