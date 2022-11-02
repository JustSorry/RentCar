using BAL.Interfaces;
using DAL.Models;
using DAL.Contracts;
using Microsoft.AspNetCore.Http;

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

        //public async Task<ActionResult<Car>> Edit(string brand, string model, string carBody, int yearOfProd, string driveType, string countryOfProd, string typeOfEngine, double engineV, string typeOfGearbox, int milleage, double dayPrice, double weekPrice, IFormFile sourceImage)
        //{
        //    var res = await Verificate(brand, model, carBody, yearOfProd, driveType, countryOfProd, typeOfEngine, engineV, typeOfGearbox, milleage, dayPrice, weekPrice, sourceImage);
        //    return res;
        //}


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

        public void DeleteRentCar(RentTime rentTime, User user)
        {
            user.RentTime = null;
            _repositoryCar.RentTimeDelete(rentTime, user);
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

        public async Task CarDelete(string path, Car car)
        {
            if (File.Exists("wwwroot" + car.ImgPath)) { File.Delete("wwwroot" + car.ImgPath); }
        }

        public async Task Update(Car car)
        {
            await _repositoryCar.Update(car);
        }
    }
}
