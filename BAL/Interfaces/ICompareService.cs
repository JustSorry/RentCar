using DAL.Models;

namespace BAL.Interfaces
{
    public interface ICompareService
    {
        Task<string> AddToCompare(User user, Car car);
        Task<string> DeleteFromCompare(User user, Car car);
        Task DeleteCompare(User user);
        IEnumerable<Compare> GetAll();
        Task Update(Compare compare);
	}
}
