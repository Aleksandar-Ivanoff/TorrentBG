namespace TorrentBG.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using TorrentBG.Services.Category.Models;
    using TorrentBG.Services.Genre.Models;

    using static TorrentBG.Data.DataConstants.Torrent;
    using static TorrentBG.Data.DataConstants.Movie;
    using static TorrentBG.Data.DataConstants.Game;
    using static TorrentBG.Data.DataConstants.Developer;
    using static TorrentBG.Data.DataConstants.Director;
    using Microsoft.AspNetCore.Http;

    public class EditTorrentFormModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter  the Torrent Name.")]
        [StringLength(MaxTorrentName, MinimumLength = MinTorrentName)]
        public string  Name { get; set; }

        [Required(ErrorMessage = "Please enter  the Description.")]
        [StringLength(MaxDescription, MinimumLength = MinDescription)]
        public string  Description { get; set; }

        [Display(Name = "Category")]
        public string  CategoryId { get; set;}
        public string CategoryName { get; set; }
        public string GenreName { get; set; }

        [Display(Name = "Genre")]
        public string GenreId { get; set; }

        [Display(Name = "Main Actors")]
        [StringLength(MaxMainActorsText, MinimumLength = MinMainActorsText)]
        public string MainActors { get; set; }

        [StringLength(MaxInstructionsLength, MinimumLength = MinInstructionsLength)]
        [Display(Name = "Instructions")]
        public string InstallInstructions { get; set; }

        [Range(MinTorrentYear, MaxTorrentYear)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Year must be in numbers only!")]
        public int Year { get; set; }

        public string DirectorId { get; set; }

        [StringLength(MaxDirectorLength, MinimumLength = MinDirectorLength)]
        [RegularExpression("[A-z ]+$", ErrorMessage = "Director name must be  with letters only!")]
        public string DirectorName { get; set; }

        public string DeveloperId { get; set; }

        [StringLength(MaxDeveloperLength, MinimumLength = MinDeveloperLength)]
        [RegularExpression("[A-z ]+$", ErrorMessage = "Developer name must be  with letters only!")]
        public string DeveloperName { get; set; }

        [Range(MinMovieLength, MaxMovieLength)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Length must be in numbers only!")]
        public int? Length { get; set; }

        public string ImagePath { get; set; }

        public IFormFile Image { get; set; }
        public IEnumerable<CategoryDropDownServiceModel> Categories { get; set; }
        public IEnumerable<GenreDropDownServiceModel> Genres { get; set; }


    }
}
