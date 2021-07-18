namespace TorrentBG.Models.Torrents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TorrentListingViewModel
    {
        public string  Id { get; set; }

        public string  Name { get; set; }

        public string Image { get; set; }

        public string  Description { get; set; }
    }
}
