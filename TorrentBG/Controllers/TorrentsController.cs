namespace TorrentBG.Controllers
{
    using System;
    using System.Collections.Generic;
    using TorrentBG.Data;
    using TorrentBG.Models.Torrents;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;
    using System.Linq;
    using TorrentBG.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.EntityFrameworkCore;
    using TorrentBG.Services.Torrent;
    using System.Threading.Tasks;
    using System.IO;
    using System.Security.Claims;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using TorrentBG.Services.Comment;
    using TorrentBG.Models.Comment;
    using Microsoft.AspNetCore.SignalR;
    using TorrentBG.Hubs;

    [Authorize]
    public class TorrentsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;
        private readonly ITorrentService torrentService;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly UserManager<User> userManager;
        private readonly ICommentService commentService;
        private readonly IHubContext<SignalrServer> hubContext;

        public TorrentsController(ApplicationDbContext dbContext, IMapper mapper, ITorrentService torrentService,
            IHostingEnvironment hostingEnvironment,UserManager<User> userManager,
            ICommentService commentService, IHubContext<SignalrServer> hubContext)
        {
            this.data = dbContext;
            this.mapper = mapper;
            this.torrentService = torrentService;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
            this.commentService = commentService;
            this.hubContext = hubContext;
        }
        public IActionResult All([FromQuery]AllTorrentsQueryModel query)
        {

            var torrentServiceModel = this.torrentService.All(searchTerm: query.SearchTerm, genre: query.Genre, category: query.Category,currentPage:query.CurrentPage,torrentsPerPage:AllTorrentsQueryModel.TorrentsPerPage);

            query = this.mapper.Map<AllTorrentsQueryModel>(torrentServiceModel);

            query.Categories = torrentServiceModel.Categories;

            query.Genres = torrentServiceModel.Genres;

            query.Torrents = torrentServiceModel.Torrents;

            return View(query);
        }

        public async Task<IActionResult> Torrent(string id)
        {
            var torrent = this.torrentService.GetTorrentById(id);
                
            var torrentModel = this.mapper.Map<TorrentDetailsViewModel>(torrent);

            var currentUser = await this.userManager.GetUserAsync(this.User);

            var comments = await this.commentService.GetCommentsAsync();

            torrentModel.Comments = comments;
            return View(torrentModel);
        }

        public async Task<IActionResult> CreateComment(CommentFormModel comment)
        {
            if (ModelState.IsValid)
            {
                comment.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                this.commentService.CreateComment(comment.CommentText,comment.UserId,comment.Id);

                return RedirectToAction("All","Torrents");
            }
            return BadRequest();
        }

        public async Task< IActionResult> GetComments()
        {
            var comments = await this.commentService.GetCommentsAsync();

            return Ok(comments);
        }

        
        public  IActionResult Download(string torrentName)
        {
            var user = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            this.torrentService.AddUserToTorrent(user, torrentName);
    
            var path = Path.Combine(hostingEnvironment.WebRootPath, "torrents");

            IFileProvider provider = new PhysicalFileProvider(path);

            torrentName = torrentName + ".torrent";
            IFileInfo fileInfo = provider.GetFileInfo(torrentName);
            var readSystem = fileInfo.CreateReadStream();
            

            var contentType = "application/x-bittorrent";
            
           
            return File(readSystem,contentType,torrentName);
        }


    }
}
