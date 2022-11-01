using DAL.Repositories;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using BAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using DAL.Data;

namespace BAL.Services
{
	public class CarService : ICarService
	{
        private ReposCar _repositoryCar = new();

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

        //public async Task<ActionResult<Car>> Edit(string brand, string model, string carBody, int yearOfProd, string driveType, string countryOfProd, string typeOfEngine, double engineV, string typeOfGearbox, int milleage, double dayPrice, double weekPrice, IFormFile sourceImage)
        //{
        //    var res = await Verificate(brand, model, carBody, yearOfProd, driveType, countryOfProd, typeOfEngine, engineV, typeOfGearbox, milleage, dayPrice, weekPrice, sourceImage);
        //    return res;
        //}


        public void RentCar(DateTime rentStartDate, DateTime rentEndDate, Car car, User user)
        {
            user.RentTime.Add(new RentTime {User = user, Car = car, RentStartTime = rentStartDate, RentEndTime = rentEndDate});
        }
      
        public void Delete(Car car)
        {
            FileService.Delete(car.ImgPath);
            _repositoryCar.Delete(car);
        }

        public async Task<Car> GetCar(Car[] allCars, int id)
        {
            return await _repositoryCar.GetCar(allCars, id);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _repositoryCar.GetAll();
        }

        public bool CheckCar(string req, Car car)
        {
            return _repositoryCar.CheckCar(req, car);
        }

        public async Task CarDelete(string path, Car car)
        {
            if (File.Exists("wwwroot" + car.ImgPath)) { File.Delete("wwwroot" + car.ImgPath); }
        }
    }
}
