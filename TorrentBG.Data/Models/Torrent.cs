namespace TorrentBG.Data.Models
{

    using System;
     using System.ComponentModel.DataAnnotations;
    using static DataConstants.Torrent;
    using static DataConstants.Movie;
    using static DataConstants.Game;
    using static DataConstants.Developer;
    using static DataConstants.Director;
    using System.Collections.Generic;

    public class Torrent
    {
        public Torrent()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Id { get; set; } 

        [Required]
        [MaxLength(MaxTorrentName)]
        
        public string Name { get; set; }

        [Required]
        [MaxLength(MaxDescription)]
        public string  Description { get; set; }

        
        public string  Image { get; set; }


        public string  DeveloperId { get; set; }

       
        public Developer Developer { get; set; }

        public string  DirectorId { get; set; }
        
        public Director Director { get; set; }

        
       
        [Required]
        public string  CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public string  GenreId { get; set; }
        public Genre Genre { get; set; }

        public int  Year { get; set; }

        public int?  Length { get; set; }

        [MaxLength(MaxInstructionsLength)]
        public string InstallInstructions { get; set; }

        [MaxLength(MaxMainActorsText)]
        public string  MainActors { get; set; }


        public ICollection<TorrentUser> Users { get; set; } = new HashSet<TorrentUser>();
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

    }
}
