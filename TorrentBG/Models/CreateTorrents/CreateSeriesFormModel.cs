namespace TorrentBG.Models.CreateTorrents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static TorrentBG.Data.DataConstants;

    public class CreateSeriesFormModel
    {
        [Required(ErrorMessage = "Please enter Series Name.")]
        [StringLength(MaxTorrentName, MinimumLength = MinTorrentName)]
        public string Name { get; init; }

        
        public string Image { get; init; }

        [Range(MinTorrentYear, MaxTorrentYear)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Year must be in numbers only!")]

        public int Year { get; init; }


        [Range(MinMovieLength, MaxMovieLength)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Length must be in numbers only!")]
        public int Length { get; init; }

        [Required(ErrorMessage = "Please enter Director name.")]
        [StringLength(MaxDirectorLength, MinimumLength = MinDirectorLength)]
        [RegularExpression("[A-z ]+$", ErrorMessage = "Director name must be only with letters only!")]
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

        public IEnumerable<TorrentsGenreViewModel> Genres { get; set; }

        public IEnumerable<TorrentsCategoryViewModel> Categories { get; set; }
    }
}
