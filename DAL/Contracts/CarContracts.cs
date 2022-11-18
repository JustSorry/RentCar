using DAL.Models;

namespace DAL.Contracts
{
    public interface IReposCar
    {
        Task Create(Car car);
        void Delete(Car car);
        Task Update(Car car);
        IEnumerable<Car> GetAll();
        bool CheckCar(string req, Car car);
        Task<Car> GetCar(int? id);
    }
}