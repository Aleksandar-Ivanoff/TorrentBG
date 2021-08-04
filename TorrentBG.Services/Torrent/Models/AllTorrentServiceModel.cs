namespace TorrentBG.Services.Torrent.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AllTorrentServiceModel
    {
        public string SearchTerm { get; set; }
        public IEnumerable<TorrentListServiceModel> Torrents { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public int TotalTorrents { get; set; }
    }
}
