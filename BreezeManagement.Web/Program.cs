using BreezeManagement.Plugins.EFCore;
using Breeze.UseCases.Features;
using BreezeManagement.UseCases.PluginInterfaces;
using BreezeManagement.UseCases.Vehicles;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using BreezeManagement.UseCases.Activities;
using BreezeManagement.UseCases.Staffs;
using BreezeManagement.UseCases.Features;
using BreezeManagement.UseCases.Interfaces.Features;
using BreezeManagement.UseCases.Interfaces.Staffs;
using BreezeManagement.UseCases.Interfaces.Vehicles;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using BreezeManagement.UseCases.Interfaces.VehicleTransactions;
using BreezeManagement.UseCases.Reports;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using BreezeManagement.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<BreezeManagementContext>(options =>
{
    //options.UseInMemoryDatabase("BreezeManagement");
    options.UseSqlServer(builder.Configuration.GetConnectionString("BreezeManagement"));
});

//Repositories
builder.Services.AddTransient<IFeatureRepository, FeatureRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IStaffRepository, StaffRepository>();
builder.Services.AddTransient<IFeatureAdditionRepository, FeatureAdditionRepository>();
builder.Services.AddTransient<IVehicleTransactionRepository, VehicleTransactionRepository>();

//Use Cases
builder.Services.AddTransient<IViewFeaturesByNameUseCase, ViewFeaturesByNameUseCase>();
builder.Services.AddTransient<IViewFeaturesByIdUseCase, ViewFeaturesByIdUseCase>();
builder.Services.AddTransient<IAddFeatureUseCase, AddFeatureUseCase>();
builder.Services.AddTransient<IEditFeatureUseCase, EditFeatureUseCase>();
builder.Services.AddTransient<IDeleteFeatureUseCase, DeleteFeatureUseCase>();
builder.Services.AddTransient<ICreateFeatureUseCase, CreateFeatureUseCase>();

builder.Services.AddTransient<IViewVehiclesByNameUseCase, ViewVehiclesByNameUseCase>();
builder.Services.AddTransient<IViewVehiclesByIdUseCase, ViewVehiclesByIdUseCase>();
builder.Services.AddTransient<IAddVehicleUseCase, AddVehicleUseCase>();
builder.Services.AddTransient<IEditVehicleUseCase, EditVehicleUseCase>();
builder.Services.AddTransient<IDeleteVehicleUseCase, DeleteVehicleUseCase>();
builder.Services.AddTransient<ICreateVehicleUseCase, CreateVehicleUseCase>();
builder.Services.AddTransient<ISellVehicleUseCase, SellVehicleUseCase>();

builder.Services.AddTransient<IViewStaffByIdUseCase, ViewStaffByIdUseCase>();
builder.Services.AddTransient<IViewStaffByNameUseCase, ViewStaffByNameUseCase>();
builder.Services.AddTransient<IAddStaffUseCase, AddStaffUseCase>();
builder.Services.AddTransient<IEditStaffUseCase, EditStaffUseCase>();
builder.Services.AddTransient<IDeleteStaffUseCase, DeleteStaffUseCase>();

builder.Services.AddTransient<ISearchVehicleTransactionsUseCase, SearchVehicleTransactionsUseCase>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth:Domain"];
    options.ClientId = builder.Configuration["Auth:ClientId"];
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ManagerPolicy", policy =>
        policy.RequireRole("manager"));

    options.AddPolicy("StaffPolicy", policy =>
        policy.RequireRole("staff"));
});

var app = builder.Build();

var scope = app.Services.CreateScope();
var breezeManagementContext = scope.ServiceProvider.GetRequiredService<BreezeManagementContext>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
