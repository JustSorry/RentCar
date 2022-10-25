using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages.Admin
{
    [Authorize(policy: "adminRights")]
    public class DeleteCarModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
