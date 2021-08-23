namespace TorrentBG.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using static DataConstants.Comment;

   public  class Comment
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(MaxTextLength)]
        public string Text { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
