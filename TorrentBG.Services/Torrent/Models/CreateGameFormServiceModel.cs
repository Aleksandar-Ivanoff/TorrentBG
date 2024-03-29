﻿namespace TorrentBG.Services.Torrent.Models
{
    using AutoMapper.Configuration.Annotations;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public  class CreateGameFormServiceModel
    {
        public string Name { get; init; }

        public IFormFile Image { get; init; }

        public int Year { get; init; }

        public string CategoryId { get; init; }

        public string GenreId { get; init; }

        public string Description { get; init; }

        public string DeveloperName { get; set; }
        public string InstallInstructions { get; set; }

        public string DeveloperId { get; set; }

        [Ignore]
        public string ImagePath { get; set; }
    }
}
