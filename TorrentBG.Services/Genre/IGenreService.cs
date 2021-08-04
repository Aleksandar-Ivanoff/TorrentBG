namespace TorrentBG.Services.Genre
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public interface IGenreService
    {
        ICollection<string> GetGenresForQuery();
        string GetGenreIdByName(string genreName);
    }
}
