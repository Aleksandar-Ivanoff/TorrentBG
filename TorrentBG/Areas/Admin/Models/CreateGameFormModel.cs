namespace TorrentBG.Areas.Admin.Models
{
    using AutoMapper.Configuration.Annotations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
  
    using static TorrentBG.Data.DataConstants.Torrent;
    using static TorrentBG.Data.DataConstants.Movie;
    using static TorrentBG.Data.DataConstants.Game;
    using static TorrentBG.Data.DataConstants.Developer;
    using static TorrentBG.Data.DataConstants.Director;
    using TorrentBG.Models.CreateTorrents;
    using TorrentBG.Services.Genre.Models;
    using TorrentBG.Services.Category.Models;
    using Microsoft.AspNetCore.Http;

    public class CreateGameFormModel
    {

        [Required(ErrorMessage = "Please enter  the Game Name.")]
        [StringLength(MaxTorrentName, MinimumLength = MinTorrentName)]
        public string Name { get; init; }

        
        public IFormFile Image { get; init; }

        [Range(MinTorrentYear, MaxTorrentYear)]
        [RegularExpression("^[0-9]+$",ErrorMessage ="Year must be in numbers only!")]
        public int Year { get; init; }

        [Display(Name="Category")]
        public string CategoryId { get; init; }

        [Display(Name = "Genre")]
        public string GenreId { get; init; }

        [Required(ErrorMessage = "Please enter  the Description.")]
        [StringLength(MaxDescription, MinimumLength = MinDescription)]

        public string Description { get; init; }

        [Required(ErrorMessage = "Please enter instructions.")]
        [StringLength(MaxInstructionsLength,MinimumLength = MinInstructionsLength)]
        [Display(Name="Instructions")]
        public string  InstallInstructions { get; set; }

        [Required(ErrorMessage = "Please enter  the Developer Name.")]
        [StringLength(MaxDeveloperLength, MinimumLength = MinDeveloperLength)]
        [RegularExpression("^[a-zA-Z0-9_.-]*$", ErrorMessage = "Developer name must be  with letters only!")]
        [Ignore]
        public string DeveloperName { get; init; }

        public string DeveloperId { get; set; }

        [Ignore]
        public IEnumerable<GenreDropDownServiceModel> Genres { get; set; }
        [Ignore]
        public IEnumerable<CategoryDropDownServiceModel> Categories { get; set; }
    }
}
