using NEXTGroup3.Client.Pages;
using NEXTGroup3.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NEXTGroup3.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<AzureContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureContext") ?? throw new InvalidOperationException("Connection string 'AzureContext' not found.")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddQuickGridEntityFrameworkAdapter();

var connection = String.Empty;
if (builder.Environment.IsDevelopment())
{
  builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
  connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
}
else
{
  connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
}

//builder.Services.AddDbContext<DbContextNext>(options =>
//    options.UseSqlServer(connection));

var app = builder.Build();

var logConnectionString = builder.Configuration.GetConnectionString("AzureContext");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(NEXTGroup3.Client._Imports).Assembly);



app.Run();
