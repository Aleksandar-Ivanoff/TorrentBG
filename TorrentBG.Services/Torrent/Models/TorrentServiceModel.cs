namespace TorrentBG.Services.Torrent.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TorrentServiceModel
    {
        public string  Name { get; set; }

        public string MainActors { get; set; }

        public string Description { get; set; }

        public string  DirectorId { get; set; }

        public string DeveloperId { get; set; }

        public string GenreId { get; set; }

        public string CategoryId { get; set;}

        public int Downloads { get; set; }

        public int ReleaseDate { get; set; }

        public string Image { get; set; }

        public int? Length { get; set; }

        public string InstallInstructions { get; set; }

        public string DeveloperName { get; set; }

        public string DirectorName { get; set; }

        public string  CategoryName { get; set; }
    }
}
