namespace TorrentBG.Common
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using TorrentBG.Data;
    using TorrentBG.Data.Models;

    using static Areas.Admin.AdminConstants;

    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app) {

            using var scopedService = app.ApplicationServices.CreateScope();

            var data = scopedService.ServiceProvider.GetService<ApplicationDbContext>();

            var serviceProvider = scopedService.ServiceProvider;

            data.Database.Migrate();

            //SeedCities(data);
            //SeedCategories(data);
            //SeedGenres(data);
            SeedAdministrator(serviceProvider);

            return app;  
          
        }

        private static void SeedCities(ApplicationDbContext db)
        {
            
            db.Cities.AddRange(new[] {

                new City{Name = "Stara Zagora"},
                new City{Name = "Sofia"},
                new City{Name = "London"},
               new City{Name = "New York"},
               new City{Name = "Varna" },
               new City{Name = "Munich"}

            });

            db.SaveChanges();
        }

        private static void SeedCategories(ApplicationDbContext db)
        {
            db.Categories.AddRange(new[] {

                new Category {Name = "Games"},
                new Category {Name = "Movies"},
                new Category {Name = "Series"},
            });
            db.SaveChanges();
        }

        private static void SeedGenres(ApplicationDbContext db)
        {
            db.Genres.AddRange(new[] {

            new Genre {Name = "Sport Simulator" },
            new Genre {Name = "Horror"},
            new Genre { Name = "Action"},
            new Genre {Name = "Comedy"},
            new Genre {Name = "Adventure"},
            new Genre { Name ="FPS"},
            new Genre { Name = "Strategy"},
            new Genre {Name = "Anime"},
            new Genre {Name = "Animation"}

            });
            db.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministratorRoleName, Id = Guid.NewGuid().ToString() };
                    await roleManager.CreateAsync(role);

                    var adminUser = new User
                    {
                        UserName = AdminUserName,
                        Email= AdminEmail,
                        FullName= "Admin"
                    };


                    await userManager.CreateAsync(adminUser, AdminPassword);

                    await userManager.AddToRoleAsync(adminUser, role.Name);

                }).GetAwaiter().GetResult();
           
                
        }
    }
}
