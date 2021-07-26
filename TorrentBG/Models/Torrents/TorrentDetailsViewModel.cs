namespace TorrentBG.Models.Torrents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TorrentDetailsViewModel
    {
        public string  Id { get; set; }

        public string  Name { get; set; }

        public string Description { get; set; }

        public int Downloads { get; set; }

        public string  InstallInstructions { get; set;}

        public string  MainActors { get; set; }

        public string  ReleaseDate { get; set; }

        public string  Length { get; set; }

        public string  Director { get; set; }

        public string CategoryName { get; set; }
        public string DirectorId { get; set; }

        public string  Developer { get; set; }

        public string DeveloperId { get; set; }
    }
}
