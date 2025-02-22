using CrudLatest.Shared.Models; // Ensure this matches your model namespace
using CrudLatest.Services; // Ensure this matches your service namespace

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMudServices();



// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices(); // Add MudBlazor

// Register HttpClient to call the Web API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5016/api/") });

// Register ItemService
builder.Services.AddScoped<ItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
