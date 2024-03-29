﻿namespace TorrentBG.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.User;

    public class User : IdentityUser
    {
        [Required]
        [MaxLength(FullNameMaxLength)]
        public string  FullName { get; set; }

       
        public string CityId { get; set; }
        public City City { get; set; }

        public string Image { get; set; }

        public ICollection<TorrentUser> Torrents { get; set; } = new HashSet<TorrentUser>();
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
