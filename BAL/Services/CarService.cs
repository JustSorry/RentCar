using BAL.Interfaces;
using DAL.Models;
using DAL.Contracts;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace BAL.Services
{
    public class CarService : ICarService
	{
        private IReposCar _repositoryCar;

        public CarService(IReposCar repositoryCar)
        {
            _repositoryCar = repositoryCar;
        }

        public async Task<ActionResult<Car>> NewCar(string brand, string model, string carBody, int yearOfProd, string driveType, string countryOfProd, string typeOfEngine, double engineV, string typeOfGearbox, int milleage, double dayPrice, double weekPrice, IFormFile sourceImage)
        {
            ActionResult<Car> actionResult = new();
            Car car = new Car()
            {
                Brand = brand,
                Model = model,
                CarBody = carBody,
                YearOfProd = yearOfProd,
                DriveType = driveType,
                CountryOfProd = countryOfProd,
                TypeOfEngine = typeOfEngine,
                EngineV = engineV,
                TypeOfGearbox = typeOfGearbox,
                Milleage = milleage,
                DayPrice = dayPrice,
                WeekPrice = weekPrice,
                ImgPath = await FileService.Save(sourceImage)

            };
            actionResult.Value = car;
            return actionResult;
        }

        public async Task<ActionResult<Car>> Add(string brand, string model, string carBody, int yearOfProd, string driveType, string countryOfProd, string typeOfEngine, double engineV, string typeOfGearbox, int milleage, double dayPrice, double weekPrice, IFormFile sourceImage)
        {
            var res = await NewCar(brand, model, carBody, yearOfProd, driveType, countryOfProd, typeOfEngine, engineV, typeOfGearbox, milleage, dayPrice, weekPrice, sourceImage);
            _repositoryCar.Create(res.Value);
            return res;
        }

        public bool RentCar(DateTime rentStartDate, DateTime rentEndDate, Car car, User user)
        {
            if (user.RentTime.Count == 0) 
            {
                user.RentTime.Add(new RentTime { UserId = user.Id, User = user, Car = car, CarId = car.Id, RentStartTime = rentStartDate, RentEndTime = rentEndDate });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ActionResult<Car>> Edit(int id, string brand, string model, string carBody, int yearOfProd, string driveType, string countryOfProd, string typeOfEngine, double engineV, string typeOfGearbox, int milleage, double dayPrice, double weekPrice, IFormFile sourceImage)
        {
            var res = await NewCar(brand, model, carBody, yearOfProd, driveType, countryOfProd, typeOfEngine, engineV, typeOfGearbox, milleage, dayPrice, weekPrice, sourceImage);
            Car car = await _repositoryCar.GetCar(id);
            car.Brand = res.Value.Brand;
            car.Model = res.Value.Model;
            car.CarBody = res.Value.CarBody;
            car.YearOfProd = res.Value.YearOfProd;
            car.DriveType = res.Value.DriveType;
            car.CountryOfProd = res.Value.CountryOfProd;
            car.TypeOfEngine = res.Value.TypeOfEngine;
            car.EngineV = res.Value.EngineV;
            car.TypeOfGearbox = res.Value.TypeOfGearbox;
            car.Milleage = res.Value.Milleage;
            car.DayPrice = res.Value.DayPrice;
            car.WeekPrice = res.Value.WeekPrice;
            car.ImgPath = res.Value.ImgPath;
            await _repositoryCar.Update(car);
            return res;
        }
      
        public void Delete(Car car)
        {
            FileService.Delete(car.ImgPath);
            _repositoryCar.Delete(car);
        }

        public async Task<Car> GetCar(int id)
        {
            return await _repositoryCar.GetCar(id);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _repositoryCar.GetAll();
        }

        public bool CheckCar(string req, Car car)
        {
            return _repositoryCar.CheckCar(req, car);
        }

        public void Update(Car car)
        {
            _repositoryCar.Update(car);
        }
    }
}
