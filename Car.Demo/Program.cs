using Car.Demo.DLL;
using Car.Demo.DLL.Entities;
using Car.Demo.DLL.Repositories;
using Car.Demo.Helpers;
using Car.Demo.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var configure = builder.Configuration;

#region Services

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<CarDbContext>(options =>
    options.UseSqlServer(configure.GetConnectionString("CarDemoConnectionString")!));

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IRepository<User>, Repository<User>>();
builder.Services.AddScoped<IRepository<Car.Demo.DLL.Entities.Car>, Repository<Car.Demo.DLL.Entities.Car>>();
builder.Services.AddScoped<IRepository<Company>, Repository<Company>>();
builder.Services.AddScoped<IRepository<Subscription>, Repository<Subscription>>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<HelperService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
        {
            options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            options.LoginPath = "/api/auth/login/";
            options.AccessDeniedPath = "/api/auth/forbidden/";
            // options.SlidingExpiration = true;
        }
    );

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

#endregion

#region Pipeline

var app = builder.Build();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<CarDbContext>();
context?.Database.EnsureDeleted();
context?.Database.EnsureCreated();
context?.Dispose();
scope.Dispose();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions()
{
    MinimumSameSitePolicy = SameSiteMode.Strict
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion
