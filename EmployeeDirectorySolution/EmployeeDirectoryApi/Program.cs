using EmployeeDirectoryApi;
using EmployeeDirectoryApi.Controllers;
using EmployeeDirectoryApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var employeeConnectionString = builder.Configuration.GetConnectionString("employees") ?? throw new Exception("Can't find the connection string");
builder.Services.AddDbContext<EmployeesDataContext>(options =>
{
    options.UseNpgsql(employeeConnectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProvideTheBusinessClock, StandardBusinessClock>();
builder.Services.AddSingleton<ISystemTime, SystemTime>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
