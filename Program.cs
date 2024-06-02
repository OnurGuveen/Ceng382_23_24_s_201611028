using Microsoft.EntityFrameworkCore;
using HotelReservationSystem.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Service configuration for Razor Pages
builder.Services.AddRazorPages();

// Configuring DbContext to use PostgreSQL with connection string from configuration
builder.Services.AddDbContext<HotelReservationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Setting up session management with specific options
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Adding IHttpContextAccessor as a singleton service
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configuring the HTTP request pipeline based on the environment
if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Enabling session management middleware
app.UseSession();

app.UseAuthorization();

// Mapping Razor Pages
app.MapRazorPages();

app.Run();
