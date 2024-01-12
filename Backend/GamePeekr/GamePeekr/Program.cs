using GamepeekrReviewManagement.Interfaces;
using GamePeekrReviewManagementDAL;
using GamePeekrReviewManagementDAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using GamePeekr.Hubs;
using GamePeekr;
using Google.Api;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddControllers();
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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
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
builder.Services.AddScoped<ISignalrService, SignalrService>();



var app = builder.Build();


app.MapHub<MessageHub>("/message");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var corsSettings = builder.Configuration.GetSection("CorsSettings");
var allowedOrigins = corsSettings.GetSection("AllowedOrigins").Get<string[]>();
app.UseCors(builder =>
    builder
        .WithOrigins(allowedOrigins)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();


public partial class Program
{
    protected Program() {}
}
