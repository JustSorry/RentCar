using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        public string Brand { get; set; } 
        public string Model { get; set; } 
        public int YearOfProd { get; set; }
        public string DriveType { get; set; } 
        public string CountryOfProd { get; set; } 
        public string TypeOfEngine { get; set; } 
        public decimal EngineV { get; set; }
        public string Color { get; set; } 
        public string TypeOfGearbox { get; set; } 
        public int Milleage { get; set; }
        public decimal DayPrice { get; set; }
        public decimal WeekPrice { get; set; }
        public decimal MonthPrice { get; set; }



        public Car(int id, string brand, string model, int yearOfProd, string driveType, string countryOfProd, string typeOfEngine, decimal engineV, string color, string typeOfGearbox, int milleage, decimal dayPrice, decimal weekPrice, decimal monthPrice)
        {
            Id = id;
            Brand = brand;
            Model = model;
            YearOfProd = yearOfProd;
            DriveType = driveType;
            CountryOfProd = countryOfProd;
            TypeOfEngine = typeOfEngine;
            EngineV = engineV;
            Color = color;
            TypeOfGearbox = typeOfGearbox;
            Milleage = milleage;
            DayPrice = dayPrice;
            WeekPrice = weekPrice;
            MonthPrice = monthPrice;
        }
    }
}
