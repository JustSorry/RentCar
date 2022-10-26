using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCar.Models;

namespace RentCar.Pages.Admin
{
    [Authorize(policy: "adminRights")]
    public class CarMngModel : PageModel
    { 
        public Car[] allCars = new Car[0];
        private Car currentCar;
        
        public static void DeleteFile(string file)
        {
            //if (File.Exists("wwwroot" + file))
            //    File.Delete("wwwroot" + file);
        }

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
            //if (!deleteCarButton) return RedirectToPage("/Index");
            if(delBtnPushed)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    //DeleteFile(car.ImgPath);
                }
                return Page();
            }
            //if(editBtnPushed)
            //{
            //    using (ApplicationContext db = new ApplicationContext())
            //    {

            //    }
            //    return 
            //}





            return Page();
            
        }
    }
}
