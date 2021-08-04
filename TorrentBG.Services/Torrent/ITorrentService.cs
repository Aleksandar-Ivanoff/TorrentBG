using System.Collections.Generic;
using System.Linq;
using TorrentBG.Data.Models;
using TorrentBG.Services.Torrent.Models;


namespace TorrentBG.Services.Torrent
{
    public interface ITorrentService
    {
        AllTorrentServiceModel All(string searchTerm, string genre, string category,int currentPage,int torrentsPerPage);
        Data.Models.Torrent GetTorrentById(string torrentId);
    }
}
