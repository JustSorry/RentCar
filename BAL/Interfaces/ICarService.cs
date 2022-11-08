using BAL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Http;

namespace BAL.Interfaces
{
    public interface ICarService
    {
        Task<ActionResult<Car>> NewCar(string brand, string model, string carBody, int yearOfProd, string driveType, string countryOfProd, string typeOfEngine, double engineV, string typeOfGearbox, int milleage, double dayPrice, double weekPrice, IFormFile sourceImage);
        Task<ActionResult<Car>> Add(string brand, string model, string carBody, int yearOfProd, string driveType, string countryOfProd, string typeOfEngine, double engineV, string typeOfGearbox, int milleage, double dayPrice, double weekPrice, IFormFile sourceImage);
        Task<ActionResult<Car>> Edit(int id, string brand, string model, string carBody, int yearOfProd, string driveType, string countryOfProd, string typeOfEngine, double engineV, string typeOfGearbox, int milleage, double dayPrice, double weekPrice, IFormFile sourceImage);
        void Delete(Car car);
        Task<Car> GetCar(int id);
        IEnumerable<Car> GetAllCars();
        bool CheckCar(string req, Car car);
        Task<string> RentCar(DateTime rentStartDate, DateTime rentEndDate, Car car, User user);
        void Update(Car car);
    }
}
