using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace RentCar.Models
{
    [Microsoft.EntityFrameworkCore.Index("CarBody", Name = "CarBody_Index")]
    public class Car
    {
        [Required][Key]
        public int CarId { get; set; }
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
    }


}
