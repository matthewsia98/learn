using Microsoft.EntityFrameworkCore;
using ehotels_data.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EhotelsDbContext>(options =>
{
	string connectionString = "Host=localhost;Database=ehotels;Username={0};Password={1}";
	string? username = Environment.GetEnvironmentVariable("EHOTELS_DB_USER");
    string? password = Environment.GetEnvironmentVariable("EHOTELS_DB_PASSWORD");
    connectionString = String.Format(connectionString, username, password);
    options.UseNpgsql(connectionString);
    //options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

