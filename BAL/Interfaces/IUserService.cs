using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BAL.Interfaces
{
    public interface IUserService
    {
        Task Update(User user);
        Task AddRole(User user, string roleName);
        string[] GetRoles(User user);
        Task RemoveRole(User user, string roleName);
        Task<SignInResult> Login(string username, string password, bool remember);
        Task Logout();
        Task<IdentityResult> Register(string username, string email, string passwordConfirm, string password);
        IEnumerable<User> GetAllUsers();
        Task<User> GetUser(string id);
    }
}
