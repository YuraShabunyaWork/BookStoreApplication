using BookStoreApplication.Interfases;
using BookStoreApplication.Models;
using BookStoreApplication.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddSingleton(new BookStore() 
    { Books = new List<Book>(), Faker = new Bogus.Faker("en")});
builder.Services.AddScoped<IManageBookStore, ManageBookStore>();

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
