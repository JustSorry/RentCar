using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.DAL.Models;
using DAL.Contracts;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace DAL.Repositories
{
	public class ReposUser : IReposUser<User>
	{
        private SignInManager<User> _signInManager;
		private UserManager<User> _userManager;

        public ReposUser(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        async Task<IdentityResult> IReposUser<User>.Create(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        void IReposUser<User>.Delete(User user)
        {
            _userManager.DeleteAsync(user);
        }

        async Task IReposUser<User>.Update(User user)
        {
            await _userManager.UpdateAsync(user);
        }

        IEnumerable<User> IReposUser<User>.GetAll()
        {
            return _userManager.Users.ToList();
        }

        //User IRepos<User>.GetById(int id)
        //{
        //    string Id = Convert.ToString(id);
        //    List<User> allUsers = _userManager.Users.ToList();
        //    foreach(User user in allUsers)
        //    { 
        //        if ( user.Id == Id)
        //        {
        //            return user;
        //        }
        //    }
        //}

        public async Task<SignInResult> Login(string username, string password, bool remember)
        {
            return await _signInManager.PasswordSignInAsync(username, password, remember, false);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task AddRole(User user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }

        public IList<string> GetRoles(User user)
        {
            return _userManager.GetRolesAsync(user).Result;
        }

        public async Task RemoveRole(User user, string role)
        {
            await _userManager.RemoveFromRoleAsync(user, role);
        }

        

    }


}
