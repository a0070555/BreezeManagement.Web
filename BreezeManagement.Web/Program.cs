using Breeze.Plugins.EFCore;
using Breeze.UseCases.Features;
using Breeze.UseCases.Interfaces;
using Breeze.UseCases.PluginInterfaces;
using BreezeManagement.UseCases.Interfaces;
using BreezeManagement.UseCases.Vehicles;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<BreezeManagementContext>(options =>
{
    options.UseInMemoryDatabase("BreezeManagement");
    //options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryManagement"));
});

//Repositories
builder.Services.AddTransient<IFeatureRepository, FeatureRepository>();

//Use Cases
builder.Services.AddTransient<IViewFeaturesByNameUseCase, ViewFeaturesByNameUseCase>();
builder.Services.AddTransient<IViewFeaturesByIdUseCase, ViewFeaturesByIdUseCase>();
builder.Services.AddTransient<IAddFeatureUseCase, AddFeatureUseCase>();
builder.Services.AddTransient<IEditFeatureUseCase, EditFeatureUseCase>();

builder.Services.AddTransient<IViewVehiclesByNameUseCase, IViewVehiclesByNameUseCase>();
builder.Services.AddTransient<IViewVehiclesByIdUseCase, IViewVehiclesByIdUseCase>();
builder.Services.AddTransient<IAddVehicleUseCase, AddVehicleUseCase>();
builder.Services.AddTransient<IEditVehicleUseCase, EditVehicleUseCase>();
builder.Services.AddTransient<IDeleteVehicleUseCase, DeleteVehicleUseCase>();



var app = builder.Build();

var scope = app.Services.CreateScope();
var imsContext = scope.ServiceProvider.GetRequiredService<BreezeManagementContext>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
