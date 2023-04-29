using WebAppDepartment.DAL;
using Microsoft.EntityFrameworkCore;
using WebAppDepartment.DAL.Data.Context;
using WebAppDepartment.DAL.Data.Repos;
using WebAppDepartment.DAL.Data.Repos.DepartmentRepos;
using WebAppDepartment.BL;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<IDepertmentManager, DepartmentManager>();

var connectionString = builder.Configuration.GetConnectionString("MyConnectionString");
builder.Services.AddDbContext<DepartmentContext>(options =>
    options.UseNpgsql(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
