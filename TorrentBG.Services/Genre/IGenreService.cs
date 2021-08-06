namespace TorrentBG.Services.Genre
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Services.Genre.Models;

    public interface IGenreService
    {
        ICollection<string> GetGenresNameForQuery();
        string GetGenreIdByName(string genreName);

        IEnumerable<GenreDropDownServiceModel> GetGenresForDropDown();
    }
}
