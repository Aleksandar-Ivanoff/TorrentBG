namespace TorrentBG.Services.Torrent.Models
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateMovieFormServiceModel
    {
        public string Name { get; set; }

        public IFormFile Image { get; set; }

        public int Year { get; set; }

        public int Length { get; set; }

        public string DirectorName { get; set; }

        public string DirectorId { get; set; }

        public string MainActors { get; set; }

        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string GenreId { get; set; }

        public string ImagePath { get; set; }
    }
}
