namespace TorrentBG.App.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using TorrentBG.Areas.Admin;
    using TorrentBG.Data;
    using TorrentBG.Models;
    using TorrentBG.Models.CreateTorrents;
    using TorrentBG.Models.Home;
    using TorrentBG.Services.Torrent;

    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext data;
        private readonly ITorrentService torrentService; 

        public HomeController(IMapper mapper,ApplicationDbContext dbContext, ITorrentService torrentService)
        {
            this.mapper = mapper;
            this.data = dbContext;
            this.torrentService = torrentService;
        }

        public IActionResult Index()         {            if (this.User.IsInRole(AdminConstants.AdministratorRoleName))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }            var torrents = this.torrentService.GetNewestTorrents().ProjectTo<NewestTorrentsViewModel>(this.mapper.ConfigurationProvider).ToList();            return View(torrents);        }        public IActionResult Error() => View(new ErrorViewModel());    }
}
