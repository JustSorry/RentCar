﻿using Microsoft.AspNetCore.Identity;

namespace RentCar.DAL.Models
{
    public class User : IdentityUser
    {
        //public new int Id { get; set; }
        //public string? Fname { get; set; } 
        //public string? Sname { get; set; } 
        //public int? Age { get; set; } 
        //public string? PhoneNum { get; set; }
        //public string? Password { get; set; }
        public double Money { get; set; }
    }
}