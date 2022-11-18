using BAL.Interfaces;
using DAL.Contracts;
using DAL.Models;
using Microsoft.AspNetCore.Http;

namespace BAL.Services
{
    public class CarService : ICarService
	{
        private IReposCar _repositoryCar;
        private IRentTimeService _rentTimeService;
        private IEnumerable<RentTime> _rentTimeList;

        public CarService(IReposCar repositoryCar, IRentTimeService rentTimeService)
        {
            _repositoryCar = repositoryCar;
            _rentTimeService = rentTimeService;
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
            await _repositoryCar.Create(res.Value);
            return res;
        }

        public async Task<string> RentCar(DateTime rentStartDate, DateTime rentEndDate, Car car, User user)
        {
            if (rentEndDate == new DateTime(0001, 01, 01, 00, 00, 00)) { return "error-end-date-uncorrect"; }
            if (user.RentTime.Count == 0) 
            {
                _rentTimeList = await _rentTimeService.GetAllTimes();
                foreach (RentTime time in _rentTimeList)
                {
                    if (time.CarId == car.Id)
                    {                                                                                                                         //ПРОВЕРКИ НА КОНФЛИКТЫ ВРЕМЕН НАЧАЛА И КОНЦА АРЕНДЫ ОПРЕДЕЛЕННОЙ МАШИНЫ МЕЖДУ РАЗНЫМИ ПОЛЬЩОВАТЕЛЯМИ
                        if ((time.RentStartTime <= rentStartDate && rentStartDate <= time.RentEndTime) ||                                     //День начала больше/равно с пересекающимся существующим днем начала и при этом меньше/равно дню окончания
                            (rentStartDate < time.RentStartTime && rentEndDate <= time.RentEndTime) ||                                           //День начала меньше/равно с пер. сущ. днем начала и при этом меньше/равно дню окончания
                            (rentStartDate >= time.RentStartTime && rentEndDate <= time.RentEndTime) ||                                        //Дни начала и окончанию полностью или частично находятся в диапазоне существующей аренды
                            (rentStartDate <= time.RentEndTime && rentEndDate >= time.RentEndTime))                                              //День начала находится в диапазоне существующей аренды, день окончания больше/равен дню окончания сущ. аренды
                        {
                            return "error-car-unavailable";
                        }
                    }
                }
                user.RentTime.Add(new RentTime { UserId = user.Id, CarId = car.Id, RentStartTime = rentStartDate, RentEndTime = rentEndDate });
                return "success";
            }
            else return "error-havecar";
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

        public async Task<Car> GetCar(int? id)
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
