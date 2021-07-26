namespace TorrentBG.App.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using TorrentBG.Data;
    using TorrentBG.Models;
    using TorrentBG.Models.CreateTorrents;
    using TorrentBG.Models.Home;

    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext data;

        public HomeController(IMapper mapper,ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.data = dbContext;
        }




        public IActionResult Index()         {            var torrents = this.data.Torrents.ProjectTo<NewestTorrentsViewModel>(mapper.ConfigurationProvider).OrderByDescending(x => x.Id).ToList();            return View(torrents);        }    }
}
