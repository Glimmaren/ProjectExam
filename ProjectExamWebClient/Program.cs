using System.Runtime.CompilerServices;
using Blazored.SessionStorage;
using Firebase.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using ProjectExamWebClient.Data;
using ProjectExamWebClient.Data.Services.AuthProvider;
using ProjectExamWebClient.Data.Services.CustomerServices;
using ProjectExamWebClient.Interfaces;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddSyncfusionBlazor();

builder.Services.AddHttpClient<IPersonLoginService, PersonService>(x =>
{
    x.BaseAddress = new Uri("http://host.docker.internal:8004/api/");
    ////x.DefaultRequestHeaders.Add("User-Agent", "ProjectExamApp");
});

builder.Services.AddHttpClient<IRoleService, RoleService>(x =>
{
    x.BaseAddress = new Uri("http://host.docker.internal:8004/api/");
    ////x.DefaultRequestHeaders.Add("User-Agent", "ProjectExamApp");
});

builder.Services.AddHttpClient<ICompanyService, CompanyService>(x =>
{
    x.BaseAddress = new Uri("http://host.docker.internal:8004/api/");
    ////x.DefaultRequestHeaders.Add("User-Agent", "ProjectExamApp");
});

builder.Services.AddSingleton<HttpClient>();


builder.Services.AddScoped<AuthenticationStateProvider, StateProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzUzOTIzQDMyMzAyZTMzMmUzMGJKQ2ZEMy9HaXVRdFhjNmF5SFZOL1BoRFJ1WDdPT1V0U3hOUm9idW4rNmM9");
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
app.UseAuthentication();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
