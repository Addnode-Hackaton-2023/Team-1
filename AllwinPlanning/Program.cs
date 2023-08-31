using AllwinPlanning.Core.Interfaces;
using AllwinPlanning.Infrastructure;
using AllwinPlanning.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration["DefaultConnection"];

// Add services to the container.
builder.Services.AddDbContext<AllwinContext>(options =>
options.UseSqlServer(connString, x => x.UseNetTopologySuite()));
var dbBuilderContext = new DbContextOptionsBuilder<AllwinContext>();
dbBuilderContext.UseSqlServer(connString, x => x.UseNetTopologySuite());
using var context = new AllwinContext(dbBuilderContext.Options);
context.Database.Migrate();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AllwinContext>();
builder.Services.AddScoped<IAllwinRepository, AllWinRepository>();

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
