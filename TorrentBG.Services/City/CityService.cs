namespace TorrentBG.Services.City
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Data;
    using TorrentBG.Services.City.Models;
    using TorrentBG.Data.Models;

    public class CityService : ICityService
    {
        private readonly ApplicationDbContext data;
        public CityService(ApplicationDbContext dbContext)
        {
            this.data = dbContext;
        }

        public IQueryable<CityListServiceModel> GetCities() => this.data.Cities.Select(x => new CityListServiceModel { Id = x.Id, Name = x.Name }).AsQueryable();

        public City GetCityById(string cityId) => this.data.Cities.FirstOrDefault(x=>x.Id == cityId);
     
        

        public string GetCityNameByUserId(string userId)
        {
            var cityName = this.data.Cities.Where(x => x.Users.Any(x => x.Id == userId)).FirstOrDefault();

            if (cityName == null)
            {
                return null;
            }

            return cityName.Name;
        }
    }
}
