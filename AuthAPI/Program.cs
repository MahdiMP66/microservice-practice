using AuthAPI.Data;
using AuthAPI.Models;
using AuthAPI.Services;
using AuthAPI.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{   options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase= false;
    options.Password.RequireLowercase= false;
    options.Password.RequireDigit= false;
    options.Password.RequiredLength = 4;
})
    .AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IAuthService, AuthService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
