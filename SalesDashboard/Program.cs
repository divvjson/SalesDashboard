using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.EntityFrameworkCore;
using SalesDashboard.Components;
using SalesDashboard.Entities;
using SalesDashboard.Helpers;
using SalesDashboard.Services.Scoped.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<AdventureWorksContext>(options =>
{
    var dataSource = builder.Environment.IsDevelopment() ? SecretsHelper.GetValue("DbDataSource") : "localhost";
    var initialCatalog = SecretsHelper.GetValue("DbInitialCatalog");
    var userId = SecretsHelper.GetValue("DbUserID");
    var password = SecretsHelper.GetValue("DbPassword");

    options
        .UseLazyLoadingProxies()
        .UseSqlServer($"Data Source={dataSource};Initial Catalog={initialCatalog};User ID={userId};Password={password};Encrypt=False");
});

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

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
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

if (app.Environment.IsDevelopment())
{
    app.Urls.Add("https://localhost:4200");
    app.Urls.Add("https://0.0.0.0:4200");
}

app.Run();
