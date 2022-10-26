using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCar.Models;

namespace RentCar.Pages.Admin
{
    public class Operations
    {
        public static void CarDelete(string path, Car car)
        {
            if (File.Exists("wwwroot" + car.ImgPath)) { File.Delete("wwwroot" + car.ImgPath); }
        }

        //public static Car CarEdit(Car car)
        //{
        //    
        //}
    }

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
            //if (!delBtnPushed) return RedirectToPage("/Index");
            if (delBtnPushed)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Operations.CarDelete(currentCar.ImgPath, currentCar);
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
