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

    [Authorize]
    public class TorrentsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;
        private readonly ITorrentService torrentService;

        public TorrentsController(ApplicationDbContext dbContext, IMapper mapper, ITorrentService torrentService)
        {
            this.data = dbContext;
            this.mapper = mapper;
            this.torrentService = torrentService;
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

            torrentModel.Downloads = torrent.Users.Count;

            return View(torrentModel);
        }


    }
}
