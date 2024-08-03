using BookStore.Models.Domain;
using BookStore.Repository.Abstract;
using BookStore.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
builder.Services.AddScoped<IGenreServices, GenreServices>();
builder.Services.AddScoped<IAuthorServices, AuthorServices>();
builder.Services.AddScoped<IPublisherServices, PublisherServices>();
builder.Services.AddScoped<IBookServices, BookServices>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
