namespace TorrentBG.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TorrentBG.Models.Director;
    using TorrentBG.Services.Director;
    using TorrentBG.Services.Torrent;

    public class DirectorController : Controller
    {
        private readonly IDirectorService directorService;
        private readonly IMapper mapper;
        private readonly ITorrentService torrentService;
        public DirectorController(IDirectorService directorService,IMapper mapper,ITorrentService torrentService)
        {
            this.directorService = directorService;
            this.mapper = mapper;
            this.torrentService = torrentService;
        }
        public IActionResult Torrents(string Id)
        {
            var directorName = this.directorService.GetDirectorName(Id);
            var directorServiceModel = this.directorService.GetDirector(directorName);

            var director = this.mapper.Map<DirectorViewModel>(directorServiceModel);

            director.Torrents = this.torrentService.GetTorrentsByDirector(directorServiceModel.Id);

            
            return View(director);
        }
    }
}
