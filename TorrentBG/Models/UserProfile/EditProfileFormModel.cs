namespace TorrentBG.Models.UserProfile
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using static TorrentBG.Data.DataConstants.User;

    public class EditProfileFormModel
    {
        public string  Id { get; set; }
        [Required]
        [StringLength(UserNameMaxLength,MinimumLength =UserNameMinLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(FullNameMaxLength,MinimumLength =FullNameMinLength)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }
        public string CityId { get; set; }

        public IEnumerable<CitiesListingViewModel> Cities { get; set; }
    }
}
