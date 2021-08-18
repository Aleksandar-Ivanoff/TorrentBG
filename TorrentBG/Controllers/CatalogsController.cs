using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TorrentBG.Models.Catalog;
using TorrentBG.Services.Genre;
using TorrentBG.Services.Torrent;

namespace TorrentBG.App.Controllers
{
    [Authorize]
    public class CatalogsController : Controller
    {
        private readonly ITorrentService torrentService;
        private readonly IGenreService genreService;
        public CatalogsController(ITorrentService torrentService, IGenreService genreService)
        {
            this.torrentService = torrentService;
            this.genreService = genreService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Movies()
        {
            var movies= this.torrentService.GetMovies();
            return View(movies);
        }

        public IActionResult Games()
        {
            var movies = this.torrentService.GetGames();
            return View(movies);
        }

        public IActionResult Series()
        {
            var movies = this.torrentService.GetSeries();
            return View(movies);
        }
    }
}
