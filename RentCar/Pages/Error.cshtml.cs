using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RentCar.Pages
{
    public class ErrorModel : PageModel
    {
        public string errorText;
        public void OnGet(string error)
        {
            switch(error)
            {
                case "error-havecar":
                    errorText = "You are already have renting car. Wait for end of your car renting time or stop your actual rent";
                    break;
                case "error-car-unavb":
                    errorText = "This car is currently rented for this time. Check out available dates for rent this car. Thank you!";
                    break;
                case "error-end-date-uncorrect":
                    errorText = "Date of the end of rent time is uncorrect. Try again.";
                    break;
            }
        }
    }
}
