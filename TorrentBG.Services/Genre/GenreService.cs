namespace TorrentBG.Services.Genre
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Data;
    using TorrentBG.Services.Genre.Models;

    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext data;

        public GenreService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public string GetGenreIdByName(string genreName) => this.data.Genres.Where(x => x.Name == genreName).Select(x => x.Id).Single();

        public IEnumerable<GenreDropDownServiceModel> GetGenresForDropDown()
        {
            return this.data.Genres
                 .Select(x => new GenreDropDownServiceModel
                 {
                     Id = x.Id,
                     Name = x.Name
                 })
                 .ToList();
        }

        public ICollection<string> GetGenresNameForQuery()
        {
            return this.data.Genres.Select(x => x.Name).ToList();
        }
    }
}
