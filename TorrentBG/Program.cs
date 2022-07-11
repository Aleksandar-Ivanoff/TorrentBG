using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TorrentBG.Common;
using TorrentBG.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.RegisterIdentity();
builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.RegisterAutoMapper();
builder.Services.RegisterServices();
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();


var app = builder.Build();


//Configure the HTTP request pipeline
app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.PrepareDatabase();

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
        name: "Areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();


   //endpoints.MapHub<SignalrServer>("/signalrserver");
});
app.Run();