using NEXTGroup3.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NEXTGroup3.Data;
using NEXTGroup3.Controllers;
using NEXTGroup3.Services;
using NEXTGroup3.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<AzureContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureContext") ?? throw new InvalidOperationException("Connection string 'AzureContext' not found.")));

builder.Services.AddDbContext<AzureContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("AzureContext")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<TextAnswerService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<RangeQuestionService>();
builder.Services.AddScoped<ResultService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<EncouragingMessageService>();


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

builder.Services.AddDbContextFactory<AzureContext>(options =>
    options.UseSqlServer("YourConnectionString", sqlOptions => 
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(3),
            errorNumbersToAdd: null);
    }), ServiceLifetime.Scoped);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(NEXTGroup3.Client._Imports).Assembly);


app.Run();
