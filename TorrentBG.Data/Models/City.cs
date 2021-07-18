namespace TorrentBG.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    
    public class City
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(MaxCityLength)]
        public string Name { get; set; }
    }
}
