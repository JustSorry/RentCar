using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace DAL.Contracts
{
    public interface IReposUser
    {
        Task GiveRole(User user, string role);
        string[] GetRoles(User user);
        Task RemoveRole(User user, string role);
        Task Update(User user);
        Task<SignInResult> Login(string username, string password, bool remember);
        Task Logout();
        Task<IdentityResult> Create(User user, string password);
        Task<User> GetUser(string id);
        IEnumerable<User> GetAll();
    }
}