using DAL.Contracts;
using Microsoft.AspNetCore.Identity;

namespace DAL.Repositories
{
	public class ReposRole : IReposRole
	{
		private RoleManager<IdentityRole> _roleManager;

		public ReposRole(RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public async Task Create(string[] roles)
		{
			foreach(string role in roles)
			{
				await _roleManager.CreateAsync(new IdentityRole(role));
			}
		}
	}
}
