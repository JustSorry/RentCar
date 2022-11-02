using BAL.Interfaces;
using DAL.Contracts;
using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BAL.Services;

public class UserService : IUserService
{
    public readonly IReposUser _repository;
    

    public UserService(IReposUser reposUser)
    {
        _repository = reposUser;    
    }

    public async Task AddRole(User user, string roleName)
    {
        await _repository.GiveRole(user, roleName);
    }

    public string[] GetRoles(User user)
    {
        return _repository.GetRoles(user);
    }

    public async Task RemoveRole(User user, string roleName)
    {
        await _repository.RemoveRole(user, roleName);
    }

    public async Task<SignInResult> Login(string username, string password, bool remember)
    {
        return await _repository.Login(username, password, remember);
    }

    public async Task Logout()
    {
        await _repository.Logout();
    }

    public async Task<IdentityResult> Register(string username, string email, string passwordConfirm, string password)
    {
        if (password != passwordConfirm)
        {
            return IdentityResult.Failed(new IdentityError() { Description = "Passwords are not compare" });
        }

        var result = await _repository.Create(new User() { UserName = username, Email = email }, password);

        if (result.Succeeded)
        {
            await Login(username, password, false);
        }
        return result;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _repository.GetAll();
    }

    public async Task<User> GetUser(string id)
    {
        return await _repository.GetUser(id);
    }

    public async Task Update(User user)
    {
        await _repository.Update(user);
    }
}