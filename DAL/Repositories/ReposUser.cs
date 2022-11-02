using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DAL.Contracts;

namespace DAL.Repositories
{
	public class ReposUser : IReposUser
	{
        private SignInManager<User> _signInManager;
		private UserManager<User> _userManager;

        public ReposUser(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Create(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task Update(User user)
        {
            await _userManager.UpdateAsync(user);
        }

        public void Delete(User user)
        {
            _userManager.DeleteAsync(user);
        }


        public async Task<User> GetUser(string id)
        {
            return _userManager.Users.Include(user => user.RentingCars).Include(user => user.RentTime).First(user=>user.Id == id);
        }
       
        public IEnumerable<User> GetAll()
        {
            return _userManager.Users.ToList();
        }

        public async Task<SignInResult> Login(string username, string password, bool remember)
        {
            return await _signInManager.PasswordSignInAsync(username, password, remember, false);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task GiveRole(User user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }

        public string[] GetRoles(User user)
        {
            return _userManager.GetRolesAsync(user).Result.ToArray();
        }

        public async Task RemoveRole(User user, string role)
        {
            await _userManager.RemoveFromRoleAsync(user, role);
        }
    }
}
