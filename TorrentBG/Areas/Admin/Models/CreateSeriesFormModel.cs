namespace TorrentBG.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static TorrentBG.Data.DataConstants.Torrent;
    using static TorrentBG.Data.DataConstants.Movie;
    using static TorrentBG.Data.DataConstants.Game;
    using static TorrentBG.Data.DataConstants.Developer;
    using static TorrentBG.Data.DataConstants.Director;
    using TorrentBG.Models.CreateTorrents;
    using TorrentBG.Services.Category.Models;
    using TorrentBG.Services.Genre.Models;
    using Microsoft.AspNetCore.Http;

    public class CreateSeriesFormModel
    {
        [Required(ErrorMessage = "Please enter Series Name.")]
        [StringLength(MaxTorrentName, MinimumLength = MinTorrentName)]
        public string Name { get; init; }

        
        public IFormFile Image { get; init; }

        [Range(MinTorrentYear, MaxTorrentYear)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Year must be in numbers only!")]

        public int Year { get; init; }


        [Range(MinMovieLength, MaxMovieLength)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Length must be in numbers only!")]
        public int Length { get; init; }

        [Required(ErrorMessage = "Please enter Director name.")]
        [StringLength(MaxDirectorLength, MinimumLength = MinDirectorLength)]
        [RegularExpression("^[a-zA-Z0-9_.-]*$", ErrorMessage = "Director name must be  with letters only!")]
        public string DirectorName { get; init; }

        public string DirectorId { get; set; }

        [Required(ErrorMessage = "Please enter Main Actors.")]
        [Display(Name = "Main Actors")]
        [StringLength(MaxMainActorsText, MinimumLength = MinMainActorsText)]
       
        public string MainActors { get; init; }

        [Required(ErrorMessage = "Please enter the Description!")]
        [StringLength(MaxDescription, MinimumLength = MinDescription)]
        public string Description { get; init; }

        [Display(Name = "Category")]
        public string CategoryId { get; init; }

        [Display(Name = "Genre")]
        public string GenreId { get; init; }

        public IEnumerable<GenreDropDownServiceModel> Genres { get; set; }

        public IEnumerable<CategoryDropDownServiceModel> Categories { get; set; }
    }
}
