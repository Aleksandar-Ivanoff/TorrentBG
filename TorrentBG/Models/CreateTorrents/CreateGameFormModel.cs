namespace TorrentBG.Models.CreateTorrents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
  
    using static TorrentBG.Data.DataConstants;
    public class CreateGameFormModel
    {

        [Required(ErrorMessage = "Please enter  the Game Name.")]
        [StringLength(MaxTorrentName, MinimumLength = MinTorrentName)]
        public string Name { get; init; }

        [Required]
        public string Image { get; init; }

        [Range(MinTorrentYear, MaxTorrentYear)]
        [RegularExpression("^[0-9]+$",ErrorMessage ="Year must be in numbers only!")]
        public int Year { get; init; }

        [Display(Name="Category")]
        public int CategoryId { get; init; }

        [Display(Name = "Genre")]
        public int GenreId { get; init; }

        [Required(ErrorMessage = "Please enter  the Description.")]
        [StringLength(MaxDescription, MinimumLength = MinDescription)]

        public string Description { get; init; }

        [Required(ErrorMessage = "Please enter instructions.")]
        [StringLength(MaxInstructionsLength,MinimumLength = MinInstructionsLength)]
        [Display(Name="Instructions")]
        public string  InstallInstructions { get; set; }

        [Required(ErrorMessage = "Please enter  the Developer Name.")]
        [StringLength(MaxDeveloperLength, MinimumLength = MinDeveloperLength)]
        [RegularExpression("[A-z]+$", ErrorMessage = "Developer name must be  with letters only!")]
        public string Developer { get; init; }


        public IEnumerable<TorrentsGenreViewModel> Genres { get; set; }
        public IEnumerable<TorrentsCategoryViewModel> Categories { get; set; }
    }
}
