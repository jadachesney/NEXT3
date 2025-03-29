using NEXTGroup3.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NEXTGroup3.Data;
using NEXTGroup3.Controllers;
using NEXTGroup3.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using NEXTGroup3;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NEXTGroup3.Models;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<AzureContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureContext") ?? throw new InvalidOperationException("Connection string 'AzureContext' not found.")));

builder.Services.AddIdentity<NextUser, IdentityRole>()
    .AddEntityFrameworkStores<AzureContext>()
    .AddDefaultTokenProviders();


builder.Services.AddHttpContextAccessor();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddResponseCaching();



//Cookie-based authentication

builder.Services.AddAuthentication(options =>
{
  options.DefaultScheme = Constant.Authscheme;
  options.DefaultAuthenticateScheme = Constant.Authscheme;
  options.DefaultSignInScheme = Constant.Authscheme;
  options.DefaultChallengeScheme = Constant.Authscheme;
})
    .AddCookie(Constant.Authscheme, options =>
    {
      options.Cookie.Name = "candidate_auth_token";
      options.LoginPath = "/CandidateLogin";
      options.AccessDeniedPath = "/access-denied";
      options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
      options.SlidingExpiration = true;
      options.Cookie.HttpOnly = true;
      options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    });


builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<TextAnswerService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<RangeQuestionService>();
builder.Services.AddScoped<LoginManagerService>();
builder.Services.AddScoped<ResultService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<CookieService>();
builder.Services.AddScoped<StaffDashboardService>();
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
builder.Services.AddHttpClient();
builder.Services.AddAuthorization();

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


//authentication middleware checks user credentials
app.UseAuthentication()
   .UseAuthorization();


app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(NEXTGroup3.Client._Imports).Assembly);


app.Run();
