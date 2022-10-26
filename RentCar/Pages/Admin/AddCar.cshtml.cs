using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCar.Models;

namespace RentCar.Pages.Admin
{
    [Authorize(policy: "adminRights")]
    
    public class AddCarModel : PageModel
    {
        public static async Task<string> CreateImgPath(IFormFile img)
        {
            string imgPath = ($"/Images/{img.FileName}");
            using (var fileStream = new FileStream("wwwroot" + imgPath, FileMode.Create))
            {
                await img.CopyToAsync(fileStream);
            }
            return imgPath;
        }

        public Car newCar = new Car();
        string ImgPath;
        public async Task<IActionResult> OnPostAsync()
        {
            newCar = new Car()
            {
                Brand = Request.Form["brand"],
                Model = Request.Form["model"],
                CarBody = Request.Form["carBody"],
                YearOfProd = Convert.ToInt32(Request.Form["yearOfProd"]),
                DriveType = Request.Form["driveType"],
                CountryOfProd = Request.Form["countryOfProd"],
                TypeOfEngine = Request.Form["typeOfEngine"],
                EngineV = Convert.ToDouble(Request.Form["engineV"]),
                TypeOfGearbox = Request.Form["typeOfGearbox"],
                Milleage = Convert.ToInt32(Request.Form["milleage"]),
                DayPrice = Convert.ToDouble(Request.Form["dayPrice"]),
                WeekPrice = Convert.ToDouble(Request.Form["weekPrice"])
            };
            if (Request.Form.Files["img"] != null) ImgPath = await CreateImgPath(Request.Form.Files["img"]);
            newCar.ImgPath = ImgPath;
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Cars.Add(newCar);
                db.SaveChanges();
            }
            return RedirectToPage("/Index");
        }
    }
}
