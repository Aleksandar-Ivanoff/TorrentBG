namespace TorrentBG.Models.Developer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TorrentBG.Services.Torrent.Models;

    public class DeveloperViewModel
    {
        public  string Name { get; set; }

        public IEnumerable<TorrentListServiceModel> Torrents { get; set;}
    }
}
