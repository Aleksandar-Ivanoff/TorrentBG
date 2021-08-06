using System.Collections.Generic;
using System.Linq;
using TorrentBG.Data.Models;
using TorrentBG.Services.Torrent.Models;


namespace TorrentBG.Services.Torrent
{
    public interface ITorrentService
    {
        AllTorrentServiceModel All(string searchTerm, string genre, string category,int currentPage,int torrentsPerPage);
        IQueryable<NewestTorrentsServiceModel> GetNewestTorrents();
        Data.Models.Torrent GetTorrentById(string torrentId);


        void CreateGame(CreateGameFormServiceModel gameModel);
        void CreateMovie(CreateMovieFormServiceModel movieModel);
        void CreateSeries(CreateSeriesFormServiceModel seriesModel);

    }
}
