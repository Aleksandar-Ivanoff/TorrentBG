namespace TorrentBG.Models.Torrents
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllTorrentsQueryModel
    {

        public const int TorrentsPerPage = 2;

        public string  SearchTerm { get; set; }

        public string  CategoryId { get; set; }

        public string  GenreId { get; set; }

        public int CurrentPage { get; set; } = 1;

        [Display(Name ="Genre")]
        public string Genre { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }


        public IEnumerable<TorrentListingViewModel> Torrents { get; set;}

        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
