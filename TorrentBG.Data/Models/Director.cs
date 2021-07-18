namespace TorrentBG.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class Director
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(MaxDirectorLength)]
        public string FullName { get; set; }

        public ICollection<Torrent> Torrents { get; set; } = new HashSet<Torrent>();
    }
}