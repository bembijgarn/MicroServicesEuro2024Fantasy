using Euro2024Stat.Web.Helper;
using Euro2024Stat.Web.Interface;
using Euro2024Stat.Web.Service;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient();
builder.Services.AddScoped<ICountry,CountryService>();
builder.Services.AddScoped<IPlayer, PlayerService>();
builder.Services.AddScoped<IMatch, MatchService>();
builder.Services.AddScoped<IAuth, AuthService>();
builder.Services.AddScoped<IToken, TokenService>();
builder.Services.AddScoped<IWallet, WalletService>();
builder.Services.AddScoped<IFantasy, FantasyService>();
builder.Services.AddScoped<ITransaction, TransactionService>();



builder.Services.AddScoped<IRequestResponse, RequestResponseService>();


ApiHelper.CountryAPIBase = builder.Configuration["ServiceUrls:CountryAPI"];
ApiHelper.PlayerAPIBase = builder.Configuration["ServiceUrls:PlayerAPI"];
ApiHelper.MatchAPIBase = builder.Configuration["ServiceUrls:MatchAPI"];
ApiHelper.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
ApiHelper.WalletAPIBase = builder.Configuration["ServiceUrls:WalletAPI"];
ApiHelper.FantasyAPIBase = builder.Configuration["ServiceUrls:FantasyAPI"];
ApiHelper.TransactionApiBase = builder.Configuration["ServiceUrls:TransactionAPI"];



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Authenticate/Login";
        options.AccessDeniedPath = "/Authenticate/Login";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Country}/{action=Index}/{id?}");

app.Run();
