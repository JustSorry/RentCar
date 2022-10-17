using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Sqlite;



namespace RentCar.Models
{
    public class Car
    {
        

        [Required]
        public int Id { get; set; }
        public string Brand { get; set; } 
        public string Model { get; set; } 
        public string CarBody { get; set; }
        public int YearOfProd { get; set; }
        public string DriveType { get; set; } 
        public string CountryOfProd { get; set; } 
        public string TypeOfEngine { get; set; } 
        public double EngineV { get; set; }
        public string Color { get; set; } 
        public string TypeOfGearbox { get; set; } 
        public int Milleage { get; set; }
        public double DayPrice { get; set; }
        public double WeekPrice { get; set; }
        public double MonthPrice { get; set; }



        public Car(int id, string brand, string model, string carBody, int yearOfProd, string driveType, string countryOfProd, string typeOfEngine, double engineV, string color, string typeOfGearbox, int milleage, double dayPrice, double weekPrice, double monthPrice)
        {
            Id = id;
            Brand = brand;
            Model = model;
            CarBody = carBody;
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

        //public void AddCarSQL(string brand, string model)
        //{
        //    //string connectionStringUsers = "Data Source = Databases\\UsersDB.db; Mode = ReadAndWrite;";
        //    //SqliteConnection Users = new SqliteConnection(connectionStringUsers);
        //    //Users.Open();

        //    string connectionStringCars = "Data Source = Databases\\RentCarDB.db; Mode = ReadAndWrite;";
        //    var Cars = new SqliteConnection(connectionStringCars);
        //    Cars.Open();

        //    SqliteCommand addCommand = new SqliteCommand($"INSERT INTO catalog VALUES({brand}, {model})", Cars);
        //}
        
    }
}
