using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Real_Estate.WebUI.Services.Favorite;
using Real_Estate.WebUI.Services.Property;
using Real_Estate.WebUI.Validation.PropertyValidator;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreatePropertyValidator>());

builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddHttpClient();

builder.Services.AddHttpContextAccessor();

//JWT tabanlý kimlik doðrulama þemasý
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index/";
opt.LogoutPath = "/Login/LogOut/";
opt.AccessDeniedPath = "/Pages/AccessDenied/";
opt.Cookie.SameSite = SameSiteMode.Strict;
opt.Cookie.HttpOnly = true;
opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
opt.Cookie.Name = "RealEstateJwt";
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
    });
});
builder.Services.AddControllers(options =>
{
	var policy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.Build();
	options.Filters.Add(new AuthorizeFilter(policy));
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
