namespace TorrentBG.Services.Comment.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class CommentServiceModel
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedOn { get; set; }


        public string UserImage { get; set; }
    }
}
