using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public class User : IdentityUser
    {
        public List<Car> RentingCars { get; set; } = new();
        public List<RentTime>? RentTime { get; set; } = new();
        public Compare? UserCompare { get; set; } = new();
    }
}