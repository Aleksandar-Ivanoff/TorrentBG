namespace TorrentBG.Models.CreateTorrents
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static TorrentBG.Data.DataConstants; 

    public class CreateMovieFormModel
    {
         [Required(ErrorMessage = "Please enter Movie Name.")]
         [StringLength(MaxTorrentName,MinimumLength = MinTorrentName)]
          public string  Name { get; init; }

        [Required]
        public string  Image { get; init; }

        [Range(MinTorrentYear,MaxTorrentYear)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Year must be in numbers only!")]

        public int Year { get; init; }

       
        [Range(MinMovieLength,MaxMovieLength)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Length must be in numbers only!")]
        public int  Length { get; init; }

        [Required(ErrorMessage = "Please enter Director name.")]
        [StringLength(MaxDirectorLength,MinimumLength = MinDirectorLength)]
        [RegularExpression("[A-z]+$",ErrorMessage ="Director name must be only with letters only!")]
        public string  Director { get; init; }

        [Required(ErrorMessage ="Please enter Main Actors.")]
        [Display(Name = "Main Actors")]
        [StringLength(MaxMainActorsText,MinimumLength = MinMainActorsText)]
        [RegularExpression("[A-z]+$", ErrorMessage = "Main Actors  must be  with letters!")]
        public string MainActors { get; init; }

        [Required(ErrorMessage = "Please enter the Description!")]
        [StringLength(MaxDescription,MinimumLength =MinDescription)]
        public string Description { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        [Display(Name = "Genre")]
        public int GenreId { get; init; }

        public IEnumerable<TorrentsGenreViewModel> Genres { get; set; }

        public IEnumerable<TorrentsCategoryViewModel> Categories { get; set; }
    }
}
