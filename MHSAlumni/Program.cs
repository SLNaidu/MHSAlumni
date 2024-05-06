using Microsoft.EntityFrameworkCore;
using MHSAlumni;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using MHSAlumni.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MhsaluminiContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection String 'Default Connection' not found")));
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
