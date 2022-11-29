using BAL.Interfaces;
using DAL.Contracts;
using DAL.Models;

namespace BAL.Services;
public class NotificationService : INotificationService
{
	private readonly IReposNotification _reposNote;
	private readonly IReposCar _reposCar;
	private readonly IUserService _userService;
	public User currentUser;
	public Car takedCar;

	public NotificationService(IReposNotification reposNote, IReposCar reposCar, IUserService userService) 
	{
		_reposNote = reposNote;
		_reposCar = reposCar;
		_userService = userService;
	}
	public async Task Add(int carId, DateTime startDate,  string userId, string message)
	{
		currentUser = await _userService.GetUser(userId);
		takedCar = await _reposCar.GetCar(carId);
		if (message == "ended")
		{
			currentUser.Notifications.Add(
				new Notification { UserId = userId, Title = "Rent has been ended", Description = $"Your rent of {takedCar.Brand} {takedCar.Model} has been ended\nThank you for your choice\nSee you later! :-)", CreatedDate = DateTime.Now});
		}
		if(message == "non-active")
		{
			currentUser.Notifications.Add(
				new Notification { UserId = userId, Title = "Successfully rent! Your rent has begin later!", Description = $"Rent of {takedCar.Brand} {takedCar.Model} has begin at {startDate}", CreatedDate = DateTime.Now });
		}
		if (message == "active")
			currentUser.Notifications.Add(
				new Notification { UserId = userId, Title = "Successfully rent!", Description = $"Your rent of {takedCar.Brand} {takedCar.Model} has begin right now!", CreatedDate = DateTime.Now });
		await _userService.Update(currentUser);
	}

	public async Task DeleteOne(string userId, int noteId)
	{
		currentUser = await _userService.GetUser(userId);
		var itemToRemove = currentUser.Notifications.Single(r => r.Id == noteId);
		currentUser.Notifications.Remove(itemToRemove);
		await _userService.Update(currentUser);
	}

	public async Task DeleteAll(string userId)
	{
		currentUser = await _userService.GetUser(userId);
		currentUser.Notifications.Clear();
		await _userService.Update(currentUser);
	}

	public async Task<IEnumerable<Notification>> GetAllUserNotes(string userId)
	{
		return await _reposNote.GetAllUserNotes(userId);
	}
}
