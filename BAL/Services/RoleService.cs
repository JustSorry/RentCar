using BAL.Interfaces;
using DAL.Contracts;

namespace BAL.Services
{
	public class RoleService : IRoleService
	{
		private IReposRole _repositoryRole;

        public RoleService(IReposRole reposRole)
        {
            _repositoryRole = reposRole;
        }

        public async Task Create(params string[] roles)
		{
			await _repositoryRole.Create(roles);
		}
	}
}
