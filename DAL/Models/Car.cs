namespace DAL.Models;
    
    public class Car
    {
        public int Id { get; set; }
        public string? Brand { get; set; } 
        public string? Model { get; set; } 
        public string? CarBody { get; set; }
        public int? YearOfProd { get; set; }
        public string? DriveType { get; set; } 
        public string? CountryOfProd { get; set; } 
        public string? TypeOfEngine { get; set; } 
        public double? EngineV { get; set; }
        public string? TypeOfGearbox { get; set; } 
        public int? Milleage { get; set; }
        public double? DayPrice { get; set; }
        public double? WeekPrice { get; set; } 
        public string? ImgPath { get; set; }
        public List<User> Users { get; set; } = new();
        public List<RentTime> RentTime { get; set; } = new();
    }
