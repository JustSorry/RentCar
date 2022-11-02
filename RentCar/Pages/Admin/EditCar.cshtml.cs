using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Models;
using DAL.Data;
using BAL.Services;
using BAL.Interfaces;

namespace RentCar.Pages.Admin
{
    [Authorize(policy: "adminRights")]
    public class EditCarModel : PageModel
    {
        private readonly ICarService _carService;
        public EditCarModel(ICarService carService)
        {
            _carService = carService;
        }

        public static Car currentCar;

        public async void OnGet(int id)
        {
            currentCar = await _carService.GetCar(id);
        }

        public async Task<IActionResult> OnPostAsync(bool delBtnPushed/*, bool editBtnPushed*/)
        {
            
            if (delBtnPushed)
            {
                await _carService.CarDelete(currentCar.ImgPath, currentCar);
                _carService.Delete(currentCar);
                await _carService.Update(currentCar);                                                 /////????????????
                return RedirectToPage("/Catalog");
            }
            return RedirectToPage("/Catalog");
        }
    }
}
