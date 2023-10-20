using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
services.AddRazorPages();

services.AddDbContext<ShopContext>(option =>
{
    option.UseSqlServer("Server=.;DataBase=BlogDB;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True");
    option.UseSqlServer(b => b.MigrationsAssembly("Blog-Web"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
