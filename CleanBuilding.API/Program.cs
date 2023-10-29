using CleanBuilding.Application;
using CleanBuilding.Application.Repository;
using CleanBuilding.Application.Services;
using CleanBuilding.Infrastructure;
using CleanBuilding.Infrastructure.Persistence;
using CleanBuilding.Infrastructure.Repository;
using CleanBuilding.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(m => m.AddPolicy("corspolicy",
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    })
);

builder.Services.AddScoped<IReadingService, ReadingService>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IDataFieldService, DataFieldService>();
builder.Services.AddScoped<IObjectService, ObjectService>();
builder.Services.AddScoped<IDapperRepository, DapperRepository>();
builder.Services.AddDbContext<MainDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corspolicy");
        
app.UseAuthorization();

app.MapControllers();

app.Run();
