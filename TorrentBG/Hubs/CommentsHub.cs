using Microsoft.AspNetCore.SignalR;
using TorrentBG.Services.Comment;
using TorrentBG.Services.Torrent;
using TorrentBG.Services.User;

namespace TorrentBG.Hubs
{
    
    public class CommentsHub:Hub
    {
        private readonly ICommentService commentService;
        private readonly IUserService userService;
        private readonly ITorrentService torrentService;
        public CommentsHub(ICommentService comment,IUserService user,ITorrentService torrent)
        {
            this.commentService = comment;
            this.userService = user;
            this.torrentService = torrent;
        }
        public async Task SendComment (string username,string comment,string torrentName)
        {
            //invoke db serve for sending params to db
            var user = this.userService.GetUserByName(username);
            var torrentId = this.torrentService.GetTorrentId(torrentName);
            this.commentService.CreateComment(comment, user.Id, torrentId);

            await Clients.All.SendAsync ("CommentIsCreated",username, comment);
        }
    }
}
