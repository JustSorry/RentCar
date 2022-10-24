using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentCar.Models;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace RentCar.Pages
{
    public class MyAccountModel : PageModel
    {
        public User? CurrentUser { get; set; }

        public void OnGet(string? Nickname)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User[] usersArray = db.Users.ToArray();
                CurrentUser = FilterUsers(usersArray, Nickname);
            }
        }

        private User FilterUsers(User[] users, string req)
        {
            User findedUser = null;
            foreach (User user in users)
            {
                if (user.UserName == req) findedUser = user;
                if (findedUser != null) break;
            }
            return findedUser;
        }
    }
}
