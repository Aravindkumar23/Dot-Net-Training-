using Microsoft.AspNetCore.Authentication.Cookies;

using Authentication;
using LogicServices;
using Repositories;
using Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepositories, ProductRepositories>();
builder.Services.AddScoped<IJsonHelperService, JSONHelperService>();
builder.Services.AddScoped<IUserFinder, UserFinder>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) 
.AddCookie(
    options => { 
    options.LoginPath = "/auth/login";
    options.LogoutPath = "/auth/logout";
}); // added for setting cookie authentication
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
app.UseAuthentication(); // added for authentication
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
