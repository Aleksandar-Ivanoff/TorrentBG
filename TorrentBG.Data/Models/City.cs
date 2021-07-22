namespace TorrentBG.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.City;
    
    public class City
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(MaxCityLength)]
        public string Name { get; set; }


        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
