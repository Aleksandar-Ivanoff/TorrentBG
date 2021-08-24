namespace TorrentBG.Services.Comment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Services.Comment.Models;

    public  interface ICommentService
    {
         Task<ICollection<CommentServiceModel>> GetCommentsAsync();

        void CreateComment(string text,string userId,string torrentId);
    }
}
