namespace TorrentBG.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TorrentBG.Models.Developer;
    using TorrentBG.Services.Developer;
    using TorrentBG.Services.Torrent;

    public class DeveloperController : Controller
    {
        private readonly IDeveloperService developerService;
        private readonly IMapper mapper;
        private readonly ITorrentService torrentService;
        public DeveloperController(IDeveloperService developerService,IMapper mapper,ITorrentService torrentService)
        {
            this.developerService = developerService;
            this.mapper = mapper;
            this.torrentService = torrentService;

        }

        public IActionResult Torrents(string Id)
        {
            var developerName = this.developerService.GetDeveloperName(Id);
            var developerServiceModel = this.developerService.GetDeveloper(developerName);

            var developer = this.mapper.Map<DeveloperViewModel>(developerServiceModel);

            developer.Torrents = this.torrentService.GetTorrentsByDeveloper(Id);
            return View(developer);
        }
    }
}
