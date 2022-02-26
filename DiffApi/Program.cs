using DiffApi.Db;
using DiffApi.Infrastructure.Repositories;
using DiffApi.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DiffContext>(options => options.UseInMemoryDatabase(databaseName: "Diff"));
builder.Services.AddScoped<ILeftDiffRepository, LeftDiffRepository>();
builder.Services.AddScoped<ILeftDiffService, LeftDiffService>();

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
