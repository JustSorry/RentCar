using DAL.Models;

namespace DAL.Contracts
{
    public interface IReposCompare
    {
        Task NewCompare(Compare compare);
        Task AddToCompare(User user, Car car);
        Task DeleteFromCompare(User user, Car car);
        Task DeleteCompare(Compare compare);
        IEnumerable<Compare> GetAll();
        Task<Compare> GetCompare(string userId, int carId);
        Task<Compare> GetUserCompare(string userId);
		Task Update(Compare compare);

	}
}
