namespace TorrentBG.Services.Comment
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Data;
    using TorrentBG.Data.Models;
    using TorrentBG.Services.Comment.Models;
    using TorrentBG.Services.User;

    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext data;
        private readonly IUserService userService;
      
        public CommentService(ApplicationDbContext data, IUserService userService)
        {
            this.data = data;
            this.userService = userService;
        }

        public void CreateComment(string text,string userId,string torrentId)
        {
            var comment = new Comment { Text = text, UserId = userId,TorrentId=torrentId};

            this.data.Comments.Add(comment);
            this.data.SaveChanges();
        }

        public async Task<ICollection<CommentServiceModel>> GetCommentsAsync()
        {
            return await this.data.Comments.Select(x => new CommentServiceModel
            {
                CreatedOn = x.CreatedOn,
                Id = x.Id,
                Text = x.Text,
                UserId = x.UserId,
                UserName = this.userService.GetUserById(x.UserId).FullName,
                UserImage = this.userService.GetUserById(x.UserId).Image


            }).ToListAsync();
        }
    }
}
