using BAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ActionResult = BAL.Services.ActionResult<DAL.Models.Car>;


namespace RentCar.Pages.Admin;

[Authorize(policy: "adminRights")]
public class EditCarModel : PageModel
{
    private readonly ICarService _carService;
    public Car editCar;
    public BAL.Services.ActionResult<Car> ActionResult = new ActionResult();

    public EditCarModel(ICarService carService)
    {
        _carService = carService;
    }

    public async Task OnGet(int id)
    {
        editCar =await _carService.GetCar(id);
    }

    public async Task<IActionResult> OnPostAsync(int id, bool delBtnPushed, bool editBtnPushed)
    {
        editCar = await _carService.GetCar(id);
        if (delBtnPushed)
        {
            _carService.Delete(editCar);
            _carService.Update(editCar);                                         
            return RedirectToPage("/Catalog");
        }
        if (editBtnPushed)
        {
            ActionResult = await _carService.Edit(
            editCar.Id,
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
            Convert.ToDouble(Request.Form["dayPrice"]),
            Convert.ToDouble(Request.Form["weekPrice"]),
            Request.Form.Files["img"]);
            editCar = ActionResult.Value ?? new();
            return RedirectToPage("/Catalog", new { Id = ActionResult.Value.Id });
        }
        return RedirectToPage("/Catalog");
    }
}

