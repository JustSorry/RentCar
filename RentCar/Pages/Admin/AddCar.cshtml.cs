using BAL.Interfaces;
using BAL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ActionResult = BAL.Services.ActionResult<DAL.Models.Car>;

namespace RentCar.Pages.Admin;
[Authorize(policy: "adminRights")]
public class AddCarModel : PageModel
{
    private ICarService _carService;
    public AddCarModel(ICarService carService)
    {
        _carService = carService;
    }

    public ActionResult ActionResult = new();
    public Car newCar = new();

    public async Task<IActionResult> OnPostAsync(bool CreateStart)
    {
        if (CreateStart)
        {
            ActionResult = await _carService.Add(
            Request.Form["brand"],
            Request.Form["model"],
            Request.Form["carBody"],
            Convert.ToInt32(Request.Form["yearOfProd"]),
            Request.Form["driveType"],
            Request.Form["countryOfProd"],
            Request.Form["typeOfEngine"],
            Convert.ToDouble(Request.Form["engineV"]),
            Request.Form["typeOfGearbox"],
            Convert.ToInt32(Request.Form["milleage"]),
            Convert.ToDouble(Request.Form["dayPrice"]),                                                                         //добавить обработку ошибок
            Convert.ToDouble(Request.Form["weekPrice"]),
            Request.Form.Files["img"]);
            newCar = ActionResult.Value ?? new();
            return RedirectToPage("/Catalog", new { Id = ActionResult.Value.Id });
            return Page();
        }
        else
            return RedirectToPage("/Admin/CarMng");
            
    }

}

