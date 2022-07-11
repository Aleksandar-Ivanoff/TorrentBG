using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TorrentBG.Data;
using TorrentBG.Data.Models;
using TorrentBG.Services.Category;
using TorrentBG.Services.City;
using TorrentBG.Services.Comment;
using TorrentBG.Services.Developer;
using TorrentBG.Services.Director;
using TorrentBG.Services.Genre;
using TorrentBG.Services.Torrent;
using TorrentBG.Services.User;

namespace TorrentBG.Infrastructure
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
          
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        } 
        public static IServiceCollection RegisterIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<ApplicationDbContext>();
            

            return services;
        }
        
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITorrentService, TorrentService>();
            services.AddTransient<IDeveloperService, DeveloperService>();
            services.AddTransient<IDirectorService, DirectorService>();
            services.AddTransient<ICommentService, CommentService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services
               .AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
