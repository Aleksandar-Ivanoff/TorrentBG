﻿namespace TorrentBG.Services.User.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public  class UserProfileServiceModel
    {
        public string  Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }
        public string  ImagePath { get; set; }
    }
}
