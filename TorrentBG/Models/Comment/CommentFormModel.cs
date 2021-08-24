namespace TorrentBG.Models.Comment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CommentFormModel
    {
        public string Id { get; set; }
        public string  CommentText { get; set; }


        public string  UserId { get; set; }
    }
}
