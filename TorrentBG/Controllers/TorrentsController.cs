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

    [Authorize]
    public class TorrentsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;
        private readonly ITorrentService torrentService;
        private readonly IHostingEnvironment hostingEnvironment;

        public TorrentsController(ApplicationDbContext dbContext, IMapper mapper, ITorrentService torrentService, IHostingEnvironment hostingEnvironment)
        {
            this.data = dbContext;
            this.mapper = mapper;
            this.torrentService = torrentService;
            this.hostingEnvironment = hostingEnvironment;
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

        public IActionResult Torrent(string id)
        {
            var torrent = this.torrentService.GetTorrentById(id);
                
            var torrentModel = this.mapper.Map<TorrentDetailsViewModel>(torrent);

            return View(torrentModel);
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
