namespace TorrentBG.Models.Catalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TorrentBG.Services.Torrent.Models;

    public class CatalogQueryModel
    {
        public string Genre { get; set; }
        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<TorrentListServiceModel> Torrents { get; set; }
    }
}
