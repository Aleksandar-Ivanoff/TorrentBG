namespace TorrentBG.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Genre;
    public class Genre
    {

        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(MaxGenreName)]
        public string Name { get; set; }


        public ICollection<Torrent> Torrents { get; set; } = new HashSet<Torrent>();
    }
}