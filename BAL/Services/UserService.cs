using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using DAL.Models;
using System.Security.Claims;
using BAL.Interfaces;

namespace BAL.Services;

public class UserService : IUserService
{
    public readonly ReposUser _repository;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _repository = new ReposUser(signInManager, userManager);    
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

    public async Task<User> GetUser(User[] users, string username)
    {
        return await _repository.GetUser(username, users);
    }

    public async Task Update(User user)
    {
        await _repository.Update(user);
    }
}