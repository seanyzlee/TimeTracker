using FluentValidation;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TimeTracker;
using TimeTracker.Data;
using TimeTracker.Extensions;
using TimeTracker.Models.Validation;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddVersioning();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddValidatorsFromAssemblyContaining<UserInputModelValidator>();
builder.Services.AddApiVersioning();
builder.Services.AddJwtBearerAuthentication(builder.Configuration);
builder.Services.AddOpenApi();

builder.Services.AddHealthChecks()
    .AddSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddHealthChecksUI().AddInMemoryStorage();
builder.Services.AddHealthChecksUI();

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
app.UseOpenApi();
app.UseSwaggerUi();
app.MapControllers();
app.UseHttpsRedirection();
app.UseHealthChecksUI();

app.UseCors(
    builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health", new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});

// Inject our custom error handling middleware into ASP.NET Core pipeline
app.UseMiddleware<ErrorHandlingMiddleware>();
//app.UseMiddleware<LimitingMiddleware>();



app.Run();
