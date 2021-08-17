namespace TorrentBG.Areas.Admin.Models
{
    using AutoMapper.Configuration.Annotations;
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

    public class CreateMovieFormModel
    {
         [Required(ErrorMessage = "Please enter Movie Name.")]
         [StringLength(MaxTorrentName,MinimumLength = MinTorrentName)]
         
        public string  Name { get; set; }

        public IFormFile  Image { get; set; }

        [Range(MinTorrentYear,MaxTorrentYear)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Year must be in numbers only!")]

        public int Year { get; set; }

       
        [Range(MinMovieLength,MaxMovieLength)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Length must be in numbers only!")]
        public int  Length { get; set; }

        [Required(ErrorMessage = "Please enter Director name.")]
        [StringLength(MaxDirectorLength, MinimumLength = MinDirectorLength)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Director name must be  with letters only!")]
        [Ignore]
        public string DirectorName { get; set; }

        public string DirectorId { get; set; }

        [Required(ErrorMessage ="Please enter Main Actors.")]
        [Display(Name = "Main Actors")]
        [StringLength(MaxMainActorsText,MinimumLength = MinMainActorsText)]
        public string MainActors { get; set; }

        [Required(ErrorMessage = "Please enter the Description!")]
        [StringLength(MaxDescription,MinimumLength =MinDescription)]
        public string Description { get; set; }

        [Display(Name = "Category")]
        public string CategoryId { get; set; }

        [Display(Name = "Genre")]
        public string GenreId { get; set; }

        [Ignore]
        public IEnumerable<GenreDropDownServiceModel> Genres { get; set; }

        [Ignore]
        public IEnumerable<CategoryDropDownServiceModel> Categories { get; set; }
    }
}
