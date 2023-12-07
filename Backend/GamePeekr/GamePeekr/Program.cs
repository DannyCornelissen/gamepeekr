using System.Security.Cryptography.X509Certificates;
using GamepeekrReviewManagement.Interfaces;
using GamePeekrReviewManagementDAL;
using GamePeekrReviewManagementDAL.Repositories;
using Google.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



string environment = builder.Environment.EnvironmentName;
string issuer = "https://securetoken.google.com/gamepeekr";
string audience = "gamepeekr";
// Use different configurations based on the environment
if (environment == "Testing")
{
    builder.Services.AddDbContext<GamePeekrDBContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("TestGamePeekrDB"),
            options => options.EnableRetryOnFailure(2));
    }, ServiceLifetime.Transient);

}
else
{
    builder.Services.AddDbContext<GamePeekrDBContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("GamePeekrDB"), 
        options=> options.EnableRetryOnFailure(2));
    }, ServiceLifetime.Transient);
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.Authority = "https://securetoken.google.com/gamepeekr";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = issuer,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = audience,
        ValidateLifetime = true
    };
});


builder.Services.AddScoped<IreviewRepository, ReviewRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
    builder
        .WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{

}
