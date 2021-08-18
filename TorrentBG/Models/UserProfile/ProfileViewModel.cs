namespace TorrentBG.Models.UserProfile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProfileViewModel
    {
        public string  Id { get; set; }
        public string  UserName { get; set;}

        public string  FullName { get; set; }

        public string Email { get; set; }

        public string  PhoneNumber { get; set; }

        public string  City { get; set; }

        public string ImagePath { get; set; }
    }
}
