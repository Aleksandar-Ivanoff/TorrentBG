using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorrentBG.Common;
using TorrentBG.Data;
using TorrentBG.Data.Models;
using TorrentBG.Hubs;
using TorrentBG.Infrastructure;



namespace TorrentBG
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          //Adding services to the container.
            services.RegisterDbContext(this.Configuration);
            services.AddSignalR(cfg=>cfg.EnableDetailedErrors = true);
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.RegisterServices();

            services
               .AddDefaultIdentity<User>(options =>
               {
                   options.Password.RequireDigit = false;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireUppercase = false;
                   options.Password.RequireNonAlphanumeric = false;
               })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
            services.RegisterAutoMapper();
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsEnvironment("azure"))
            {

                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithRedirects("/Error/OOPS");

                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

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


                endpoints.MapHub<SignalrServer>("/signalrserver");
            });
        }
    }
}
