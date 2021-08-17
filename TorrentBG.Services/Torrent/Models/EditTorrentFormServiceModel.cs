namespace TorrentBG.Services.Torrent.Models
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public  class EditTorrentFormServiceModel
   {
        public string  Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string GenreName { get; set; }

        public string GenreId { get; set; }

        public string MainActors { get; set; }

        public string InstallInstructions { get; set; }

        public int Year { get; set; }

        public string DirectorId { get; set; }

        public string DirectorName { get; set; }

        public string DeveloperId { get; set; }

        public string DeveloperName { get; set; }

        public int? Length { get; set; }
        public IFormFile  Image { get; set; }
        public string ImagePath { get; set; }


    }
}
