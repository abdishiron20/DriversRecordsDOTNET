using Dispatch_app.Models;
using Dispatch_app.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDriverRepo, DriverRepo>();
builder.Services.AddScoped<ITractorRepo, TractorRepo>();

builder.Services.AddScoped<ITrailerRepo, TrailerRepo>();  //TODO: still need more research on this 
builder.Services.AddScoped<ILoadRepo, LoadRepo>();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");  // This the defualt controller pointing the index action 

app.Run();
