namespace TorrentBG.Services.City
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Services.City.Models;
    using TorrentBG.Data.Models;

    public interface ICityService
    {
        string GetCityNameByUserId(string userId);
        City GetCityById(string cityId);
        IQueryable<CityListServiceModel> GetCities();
    }
}
