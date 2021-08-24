namespace TorrentBG.Models.Torrents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TorrentBG.Services.Comment.Models;

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

        public string  DirectorName { get; set; }

        public string CategoryName { get; set; }
        public string DirectorId { get; set; }

        public string  DeveloperName { get; set; }

        public string DeveloperId { get; set; }

        public string  Image { get; set; }

        public ICollection<CommentServiceModel> Comments { get; set; }

        public string UserImage { get; set; }

        public string CommentText { get; set; }

    }
}
