namespace TorrentBG.Models.Torrents
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TorrentBG.Services.Torrent.Models;

    public class AllTorrentsQueryModel
    {

        public const int TorrentsPerPage = 3;

        public string  SearchTerm { get; set; }

        public string  CategoryId { get; set; }

        public string  GenreId { get; set; }

        public int CurrentPage { get; set; } = 1;

        [Display(Name ="Genre")]
        public string Genre { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }


        public int TotalTorrents { get; set; }

        public IEnumerable<TorrentListServiceModel> Torrents { get; set;}

        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
