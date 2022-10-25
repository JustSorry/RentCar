using RentCar.Models;
using Microsoft.AspNetCore.Identity;

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

//using (ApplicationContext db = new ApplicationContext())
//{
//    db.Database.EnsureDeleted();
//    db.Database.EnsureCreated();

//    Car mitsPaj = new Car { Brand = "Mitsubishi", Model = "Pajero IV", CarBody = "Crossover", YearOfProd = 2008, DriveType = "4x4", CountryOfProd = "Japan", TypeOfEngine = "Diesel", EngineV = 3.2, TypeOfGearbox = "Mechanical", Milleage = 264000, DayPrice = 100.0, WeekPrice = 500.0, ImgPath = "/Images/pajero.png " };
//    Car volvoXC90 = new Car { Brand = "Volvo", Model = "XC90 I", CarBody = "Crossover", YearOfProd = 2011, DriveType = "4x4", CountryOfProd = "Sweden", TypeOfEngine = "Petrol", EngineV = 3.2, TypeOfGearbox = "Auto", Milleage = 250000, DayPrice = 200.0, WeekPrice = 1000.0, ImgPath = " " };
//    Car peug5008 = new Car { Brand = "Peugeot", Model = "5008 II", CarBody = "Crossover", YearOfProd = 2018, DriveType = "FWD", CountryOfProd = "France", TypeOfEngine = "Diesel", EngineV = 1.5, TypeOfGearbox = "Auto", Milleage = 143000, DayPrice = 400.0, WeekPrice = 2000.0, ImgPath = "/Images/peugeot5008.png " };
//    Car ladaVesta = new Car { Brand = "Lada", Model = "Vesta I", CarBody = "Sedan", YearOfProd = 2019, DriveType = "FWD", CountryOfProd = "Russia", TypeOfEngine = "Petrol", EngineV = 1.6, TypeOfGearbox = "Mechanical", Milleage = 54000, DayPrice = 35.0, WeekPrice = 175.0, ImgPath = " " };
//    Car volvoS80 = new Car { Brand = "Volvo", Model = "S80 II", CarBody = "Sedan", YearOfProd = 2010, DriveType = "FWD", CountryOfProd = "Sweden", TypeOfEngine = "Petrol", EngineV = 2.5, TypeOfGearbox = "Auto", Milleage = 180000, DayPrice = 250.0, WeekPrice = 1250.0, ImgPath = " " };
//    Car vwPoloSedan = new Car { Brand = "Volkswagen", Model = "Polo Sedan", CarBody = "Sedan", YearOfProd = 2017, DriveType = "FWD", CountryOfProd = "Germany", TypeOfEngine = "Petrol", EngineV = 1.6, TypeOfGearbox = "Mechanical", Milleage = 150000, DayPrice = 45.0, WeekPrice = 225.0, ImgPath = " " };
//    Car kiaOptima = new Car { Brand = "Kia", Model = "Optima III", CarBody = "Sedan", YearOfProd = 2012, DriveType = "FWD", CountryOfProd = "South Korea", TypeOfEngine = "Petrol", EngineV = 2.0, TypeOfGearbox = "Auto", Milleage = 120000, DayPrice = 50.0, WeekPrice = 250.0, ImgPath = "/Images/kiaOptima.png " };
//    Car fordFusion2 = new Car { Brand = "Ford", Model = "Fusion 2", CarBody = "Sedan", YearOfProd = 2019, DriveType = "FWD", CountryOfProd = "United states", TypeOfEngine = "Petrol", EngineV = 1.5, TypeOfGearbox = "Auto", Milleage = 20000, DayPrice = 65.0, WeekPrice = 325.0, ImgPath = "/Images/fordFusion.png" };
//    Car vwGolf2 = new Car { Brand = "Volkswagen", Model = "Golf mk.2", CarBody = "Hatchback", YearOfProd = 1986, DriveType = "4x4", CountryOfProd = "Germany", TypeOfEngine = "Petrol", EngineV = 1.8, TypeOfGearbox = "Mechanical", Milleage = 250000, DayPrice = 228.69, WeekPrice = 1448.69, ImgPath = "/Images/Golf2.png" };
//    Car renaultClio = new Car { Brand = "Renault", Model = "Clio RS IV", CarBody = "Hatchback", YearOfProd = 2018, DriveType = "FWD", CountryOfProd = "France", TypeOfEngine = "Petrol", EngineV = 1.6, TypeOfGearbox = "Auto", Milleage = 70000, DayPrice = 500.0, WeekPrice = 2500.0, ImgPath = "/Images/renaultClioRS.png" };
//    Car miniCabr3 = new Car { Brand = "Mini", Model = "Cabrio mk.3", CarBody = "Cabriolet", YearOfProd = 2019, DriveType = "FWD", CountryOfProd = "Great Britain", TypeOfEngine = "Petrol", EngineV = 2.0, TypeOfGearbox = "Auto", Milleage = 19000, DayPrice = 200.0, WeekPrice = 1000.0, ImgPath = "/Images/miniCabrio.png " };
//    Car vwTouran = new Car { Brand = "Volkswagen", Model = "Touran I", CarBody = "Minivan", YearOfProd = 2006, DriveType = "FWD", CountryOfProd = "Germany", TypeOfEngine = "Diesel", EngineV = 1.9, TypeOfGearbox = "Mechanical", Milleage = 310000, DayPrice = 50.0, WeekPrice = 250.0, ImgPath = " " };
//    Car kiaCarens = new Car { Brand = "Kia", Model = "Carens III", CarBody = "Minivan", YearOfProd = 2015, DriveType = "FWD", CountryOfProd = "South Korea", TypeOfEngine = "Diesel", EngineV = 1.7, TypeOfGearbox = "Mechanical", Milleage = 115000, DayPrice = 100.0, WeekPrice = 500.0, ImgPath = " " };
//    Car chevCorvette = new Car { Brand = "Chevrolet", Model = "Corvette", CarBody = "SportCar", YearOfProd = 2019, DriveType = "RWD", CountryOfProd = "United states", TypeOfEngine = "Petrol", EngineV = 6.2, TypeOfGearbox = "Auto", Milleage = 26000, DayPrice = 6000.0, WeekPrice = 30000.0, ImgPath = "/Images/chevCorvette.png" };
//    Car ferrariGTC4 = new Car { Brand = "Ferrari", Model = "GTC4", CarBody = "SportCar", YearOfProd = 2018, DriveType = "RWD", CountryOfProd = "Italy", TypeOfEngine = "Petrol", EngineV = 3.0, TypeOfGearbox = "Auto", Milleage = 200, DayPrice = 1000.0, WeekPrice = 5000.0, ImgPath = "/Images/ferrariGTC4.png " };
//    Car toyotaCelica = new Car { Brand = "Toyota", Model = "Celica", CarBody = "SportCar", YearOfProd = 2002, DriveType = "FWD", CountryOfProd = "Japan", TypeOfEngine = "Petrol", EngineV = 1.8, TypeOfGearbox = "Mechanical", Milleage = 200000, DayPrice = 400.0, WeekPrice = 2000.0, ImgPath = " " };
//    Car toyotaTundra = new Car { Brand = "Toyota", Model = "Tundra", CarBody = "Pick-up", YearOfProd = 2007, DriveType = "4x4", CountryOfProd = "Japan", TypeOfEngine = "Petrol", EngineV = 5.7, TypeOfGearbox = "Auto", Milleage = 338000, DayPrice = 500.0, WeekPrice = 2500.0, ImgPath = " " };
//    Car vwCrafter = new Car { Brand = "Volkswagen", Model = "Crafter", CarBody = "Van", YearOfProd = 2018, DriveType = "FWD", CountryOfProd = "Germany", TypeOfEngine = "Diesel", EngineV = 2.0, TypeOfGearbox = "Mechanical", Milleage = 313000, DayPrice = 300.0, WeekPrice = 1500.0, ImgPath = " " };
//    Car mbSprinter = new Car { Brand = "Mercedes-Benz", Model = "Sprinter", CarBody = "Truck", YearOfProd = 2000, DriveType = "FWD", CountryOfProd = "Germany", TypeOfEngine = "Diesel", EngineV = 2.9, TypeOfGearbox = "Mechanical", Milleage = 500000, DayPrice = 300.0, WeekPrice = 1500.0, ImgPath = " " };
//    db.Cars.AddRange(mitsPaj, volvoXC90, peug5008, ladaVesta, volvoS80, vwPoloSedan, kiaOptima, fordFusion2, vwGolf2, renaultClio, miniCabr3, chevCorvette, vwTouran, kiaCarens, ferrariGTC4, toyotaCelica, toyotaTundra, vwCrafter, mbSprinter);
//    db.SaveChanges();
//}
app.Run();