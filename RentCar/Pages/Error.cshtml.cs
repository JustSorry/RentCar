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
                case "com-is-empty":
                    errorText = "Your compare has not at least one car. Add some cars to compare them.";
                    break;
                case "havent-rent-cars":
                    errorText = "You are haven't any cars";
                    break;
				case "user-history-is-empty":
					errorText = "Your rent history is empty";
					break;
			}
        }
    }
}
