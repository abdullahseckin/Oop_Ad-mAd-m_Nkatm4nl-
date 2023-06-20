using A_Product_Nkatm4nl�_UI.Models;
using DataAccessLayer.Proje_Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.CodeAnalysis.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//66v Identity Kutuphanesi varsa Register i�in Configution ayarlar� yap�n
//builder.Services.AddDbContext<Context>();
//builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();
//68v
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomerIdentityValidator>();

// 70-72v nedir?
// bu komut uygulamadaki Authorization/login i�lemlerini proje seviyesine c�kartacak
// bundan sonra tum sayfalara Authenticated//login i�lemlerini zorunlu k�lacak
// E�er Authenticated//login de�ilsin hi�bir sayfaya ula�amazs�n
builder.Services.AddMvc(config =>
{
    var _policy=new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(_policy));
});

//75v ,
// sisteme login olan kullan�c�n�n bilgilerini conf�gure edeb�l�rz
builder.Services.ConfigureApplicationCookie(options =>
{
    // ba�lag��ta e�er kullan�c� login yapmam�� ise buraya yonlend�r
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
// bu komut uygulamadaki Authorization/login i�lemlerini proje seviyesine c�kartacak
// bundan sonra tum sayfalara Authenticated//login i�lemlerini zorunlu k�lacak
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
