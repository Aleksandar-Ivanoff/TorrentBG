namespace TorrentBG.Models.Director
{
    using AutoMapper.Configuration.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TorrentBG.Services.Torrent.Models;

    public class DirectorViewModel
    {
        public string  Name { get; set; }

        [Ignore]
        public IEnumerable<TorrentListServiceModel> Torrents { get; set; }
    }
}
