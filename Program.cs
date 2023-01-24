using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FrontEndRazor.Data;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


//builder.Services.AddHttpClient(client =>
//         client.BaseAddress = new Uri(builder.Configuration.GetSection("VentasApi").Value));
/*
builder.Services.AddDbContext<FrontEndRazorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FrontEndRazorContext") ?? throw new InvalidOperationException("Connection string 'FrontEndRazorContext' not found.")));
*/
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
