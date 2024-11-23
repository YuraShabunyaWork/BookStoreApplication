using BookStoreApplication.Interfases;
using BookStoreApplication.Models;
using BookStoreApplication.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddSingleton<BookStoreService>();
builder.Services.AddScoped<IManageBookStore, ManageBookStore>();

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
