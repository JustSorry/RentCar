using BAL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface ICarService
    {
        Task<ActionResult<Car>> NewCar(string brand, string model, string carBody, int yearOfProd, string driveType, string countryOfProd, string typeOfEngine, double engineV, string typeOfGearbox, int milleage, double dayPrice, double weekPrice, IFormFile sourceImage);
        Task<ActionResult<Car>> Add(string brand, string model, string carBody, int yearOfProd, string driveType, string countryOfProd, string typeOfEngine, double engineV, string typeOfGearbox, int milleage, double dayPrice, double weekPrice, IFormFile sourceImage);
        void Delete(Car car);
        Task<Car> GetCar(int id);
        IEnumerable<Car> GetAllCars();
        bool CheckCar(string req, Car car);
        Task CarDelete(string path, Car car);
        bool RentCar(DateTime rentStartDate, DateTime rentEndDate, Car car, User user);
        void DeleteRentCar(RentTime rentTime, User user);
        Task Update(Car car);
    }
}
