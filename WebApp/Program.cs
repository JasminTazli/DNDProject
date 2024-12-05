using System.Net;
using Domain.Auth;
using WebApp.Auth;
using WebApp.Components;
using WebApp.Services.Http;
using WebAPI.Services;
using WebAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["WebAPIBaseAddress"] ?? "https://localhost:5001") });

builder.Services.AddAuthentication().AddCookie(options =>
{
    options.LoginPath = "/login";
});

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

AuthorizationPolicies.AddPolicies(builder.Services);

builder.Services.AddDbContext<ESGContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<EdataService>();

builder.Services.Configure<Microsoft.AspNetCore.Components.Server.CircuitOptions>(options => options.DetailedErrors = true);

builder.Services.AddScoped<WebApp.Services.Http.IAuthService, JwtAuthService>(); // Specify the full namespace

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();