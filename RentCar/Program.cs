using Microsoft.AspNetCore.Identity;
using DAL.Data;
using DAL.Models;
using BAL.Interfaces;
using BAL.Services;
using DAL.Contracts;
using DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>();

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<ApplicationContext>();

//Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("adminRights", 
        policy => policy.RequireRole("admin", "moderator"));
    options.AddPolicy("moderRights",
        policy => policy.RequireRole("moderator"));
});

builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IRentTimeService, RentTimeService>();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IReposRentTime, ReposRentTime>();
builder.Services.AddTransient<IReposRole, ReposRole>();
builder.Services.AddTransient<IReposCar, ReposCar>();
builder.Services.AddTransient<IReposUser, ReposUser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();