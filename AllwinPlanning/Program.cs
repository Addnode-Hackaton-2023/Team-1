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
builder.Services.AddCors();
builder.Services.AddOpenApiDocument();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AllwinContext>();
builder.Services.AddScoped<IAllwinRepository, AllWinRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    // Add OpenAPI 3.0 document serving middleware
    // Available at: http://localhost:<port>/swagger/v1/swagger.json
    app.UseOpenApi();

    // Add web UIs to interact with the document
    // Available at: http://localhost:<port>/swagger
    app.UseSwaggerUi3();
//}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
