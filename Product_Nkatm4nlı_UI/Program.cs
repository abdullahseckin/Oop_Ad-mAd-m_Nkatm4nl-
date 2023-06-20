using A_Product_Nkatm4nlý_UI.Models;
using DataAccessLayer.Proje_Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.CodeAnalysis.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//66v Identity Kutuphanesi varsa Register için Configution ayarlarý yapýn
//builder.Services.AddDbContext<Context>();
//builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();
//68v
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomerIdentityValidator>();

// 70-72v nedir?
// bu komut uygulamadaki Authorization/login iþlemlerini proje seviyesine cýkartacak
// bundan sonra tum sayfalara Authenticated//login iþlemlerini zorunlu kýlacak
// Eðer Authenticated//login deðilsin hiçbir sayfaya ulaþamazsýn
builder.Services.AddMvc(config =>
{
    var _policy=new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(_policy));
});

//75v ,
// sisteme login olan kullanýcýnýn bilgilerini confýgure edebýlýrz
builder.Services.ConfigureApplicationCookie(options =>
{
    // baþlagýçta eðer kullanýcý login yapmamýþ ise buraya yonlendýr
    options.LoginPath = "/login/Index";
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

// 70-72v nedir?
// bu komut uygulamadaki Authorization/login iþlemlerini proje seviyesine cýkartacak
// bundan sonra tum sayfalara Authenticated//login iþlemlerini zorunlu kýlacak
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
