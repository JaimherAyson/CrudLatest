using CrudLatest.Server;
using CrudLatest.Server.Services; // Ensure this matches your service namespace
using CrudLatest.Server.Shared.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Load MongoDB settings FIRST
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

// 🔹 Register MongoDB service
builder.Services.AddScoped<IMongoDbService, MongoDbService>();

// 🔹 Register additional services
builder.Services.AddSingleton<ItemService>(); // Ensure ItemService is correctly implemented

// 🔹 Add controllers and API tools
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 Enable CORS (for Blazor to access the API)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// 🔹 Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 Enable CORS
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.Run();
