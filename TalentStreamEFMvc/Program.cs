using Microsoft.EntityFrameworkCore;
using TalentStreamEFMvc.Models;
using TalentStreamEFMvc.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TalentStreamDbContext>(options =>
    options.UseMySql(configuration.GetConnectionString("TalentStreamConnection"), new MySqlServerVersion(new Version(5, 5, 41))));
builder.Services.AddScoped<RecruiterService>();

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
