using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Models;
using DAL.Data;
using BAL.Services;

namespace RentCar.Pages.Admin
{
    [Authorize(policy: "adminRights")]
    public class EditCarModel : PageModel
    {
        public Car[] allCars = new Car[0];
        public static Car currentCar;

        public void OnGet(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                allCars = db.Cars.ToArray();
                foreach (Car car in allCars)
                {
                    if (car.Id == id)
                    {
                        currentCar = car;
                        break;
                    }
                }
            }
        }

        public async Task<IActionResult> OnPostAsync(bool delBtnPushed/*, bool editBtnPushed*/)
        {
            CarService carService = new CarService();
            if (delBtnPushed)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    carService.CarDelete(currentCar.ImgPath, currentCar);
                    db.Cars.Remove(currentCar);
                    db.SaveChanges();
                }
                return RedirectToPage("/Catalog");
            }
            //if(editBtnPushed)
            //{
            //    using (ApplicationContext db = new ApplicationContext())
            //    {

            //    }
            //    return 
            //}
            return RedirectToPage("/Catalog");
        }
    }
}
