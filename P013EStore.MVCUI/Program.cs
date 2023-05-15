using P013EStore.Data;
using P013EStore.Service.Abstract;
using P013EStore.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies; // Oturum işlemleri için 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddTransient(typeof(IService<>), typeof(Service<>)); // kendi yazd���m�z db i�lemlerini yapan servisi .net core da bu �ekilde mvc projesine servis olarak tan�t�yoruz ki kullanabilelim.

builder.Services.AddTransient<IProductService, ProductService>();// Product için yazdığımız özel servisi uygulamaya tanıttık

// Uygulama admin paneli için oturum açma ayarları
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login"; // oturum açmayan kullanıcıların giriş için gönderdiği adres
    x.LogoutPath = "/Admin/Logout"; 
    x.AccessDeniedPath = "/AccessDenied"; // yetkilendirme ile ekrana erişim hakkı olmayan kullanıcıların gönderileceği sayfa
    x.Cookie.Name = "Administrator"; // oluşacak kukinin ismi
    x.Cookie.MaxAge = TimeSpan.FromDays(1); // oluşacak kukinin yaşam süresi(1 gün)
}); // Oturum işlemleri için 

// Uygulama admin paneli için admin yetkilendirme ayarları.
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Dikkat ! önce UseAuthentication satırı gelmeli sonra UseAuthorization.
app.UseAuthorization();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
