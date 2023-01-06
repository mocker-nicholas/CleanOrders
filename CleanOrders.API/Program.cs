using CleanOrders.API.Authorization;
using CleanOrders.API.Middleware;
using CleanOrders.Application.Commands.Accounts;
using CleanOrders.Application.Interfaces;
using CleanOrders.Application.Interfaces.Repositories;
using CleanOrders.Infrastructure.Data;
using CleanOrders.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.'builder.Services.AddDbContext<DevDbContext>(options =>
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("CleanOrders.Infrastructure")
    );
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Super", policy => policy.RequireClaim(ClaimTypes.Role, "Super"));
    options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    options.AddPolicy("Standard", policy => policy.RequireClaim(ClaimTypes.Role, "Standard"));
    options.AddPolicy("SuperAndAdmin", policy => policy.RequireClaim(ClaimTypes.Role, "Super", "Admin"));
    // Permissions are going to be custom claims on the JWT
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(CreateAccountCommand).Assembly);
builder.Services.AddScoped<IAccountRepositoryAsync, AccountRepository>();
builder.Services.AddScoped<IUserRepositoryAsync, UsersRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddControllers().AddJsonOptions(options =>
{ options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Before next happens in order of invokation, after next happens in order of invokation, but in reverse
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-7.0#create-a-middleware-pipeline-with-webapplication

app.UseAuthorizationMiddleware();

app.UseGlobalErrorHandler();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

// To Do
// Add Meta Data into your database. Add models with Metadata properties
// Think about your property types and contructors. What really should be accessible, and what shouldnt?
// Throw exceptions for errors you cant do anything about. Birth date as user id? Exception
// Add a middleware or filter for Global exception handling
// Get rid of generic responses of 200 with an error message. Return the appropriate response code.
// Polish what you have
//	- Delete a user
//	- Add fluent validations for all endpoints
//	- Start using policies to dictate who does what
//	- Test everything for bugs
//	- Where is your database at? Does it need to be updated?