namespace TorrentBG.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TorrentBG.Data.Models;
    using TorrentBG.Services.Comment.Models;

    public class SignalrServer :Hub
    {
        public async Task PostComment(CommentServiceModel comment)
        {
            await Clients.All.SendAsync("CommentReceive", comment);
        } 
    }
}
