using DAL.Contracts;
using DAL.Data;
using DAL.Models;

namespace DAL.Repositories;

public class ReposNotification : IReposNotification
{
	private ApplicationContext db = new ApplicationContext();

	public async Task<IEnumerable<Notification>> GetAllUserNotes(string userId)
	{
		List<Notification> allUserNotes = new();
		foreach(Notification note in db.Notifications.ToList()) 
		{
			if(note.UserId== userId) {allUserNotes.Add(note);}
		}
		return allUserNotes;
	}
}

