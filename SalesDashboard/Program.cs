using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using SalesDashboard;
using SalesDashboard.Entities;
using SalesDashboard.Helpers;
using SalesDashboard.Services.Scoped.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<AdventureWorksContext>(options =>
{
    options
        .UseLazyLoadingProxies()
        .UseSqlServer(SecretsHelper.GetConnectionString(builder.Configuration), options => options.UseNetTopologySuite());
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddScoped<LocalStorageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

if (app.Environment.IsDevelopment())
{
    app.Urls.Add("https://localhost:4200");
    app.Urls.Add("https://0.0.0.0:4200");
}

app.Run();
