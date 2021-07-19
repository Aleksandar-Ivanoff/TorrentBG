namespace TorrentBG.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Uploader;
    public class Uploader
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(MaxUploaderName)]
        public string  Name { get; set; }

        [Required]
        public string UserId { get; set; }


        public ICollection<Torrent> Uploads = new HashSet<Torrent>();
      
    }
}
