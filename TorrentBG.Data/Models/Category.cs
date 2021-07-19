namespace TorrentBG.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Category;
    public class Category
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(MaxCategoryName)]
        public string Name { get; set; }


        public ICollection<Torrent> Torrents { get; set; } = new HashSet<Torrent>();
    }
}