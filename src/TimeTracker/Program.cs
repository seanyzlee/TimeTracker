using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TimeTracker;
using TimeTracker.Data;
using TimeTracker.Extensions;
using TimeTracker.Models.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Services.AddDbContext<TimeTrackerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddValidatorsFromAssemblyContaining<UserInputModelValidator>();
builder.Services.AddApiVersioning();
builder.Services.AddJwtBearerAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();

// Inject our custom error handling middleware into ASP.NET Core pipeline
app.UseMiddleware<ErrorHandlingMiddleware>();
app.Run();
