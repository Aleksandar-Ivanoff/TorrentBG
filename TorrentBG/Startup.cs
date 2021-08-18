using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorrentBG.Common;
using TorrentBG.Data;
using TorrentBG.Data.Models;
using TorrentBG.MappingConfiguration;
using TorrentBG.Services.Category;
using TorrentBG.Services.City;
using TorrentBG.Services.Developer;
using TorrentBG.Services.Director;
using TorrentBG.Services.Genre;
using TorrentBG.Services.Torrent;
using TorrentBG.Services.User;


namespace TorrentBG
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

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

            //AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TorrentBGProfile());
                mc.AddProfile(new TorrentBGServiceProfile());

            });
            
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllersWithViews();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITorrentService, TorrentService>();
            services.AddTransient<IDeveloperService, DeveloperService>();
            services.AddTransient<IDirectorService, DirectorService>();
           
           


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
        
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
            });
        }
    }
}
