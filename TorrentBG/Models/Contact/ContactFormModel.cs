namespace TorrentBG.Models.Contact
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using static Data.DataConstants.Contact;

    public class ContactFormModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [StringLength(MaxNameLength,MinimumLength =MinNameLength)]
        public string Name { get; set; }

        [Required]
        public string  Subject { get; set; }

        [Required]
        [MaxLength(MaxMessageLength)]
        public string  Message { get; set; }


    }
}
