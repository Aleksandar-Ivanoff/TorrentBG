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
    using TorrentBG.Models.CreateTorrents;

    public class TorrentsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public TorrentsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.data = dbContext;
            this.mapper = mapper;
        }
        public IActionResult All([FromQuery]AllTorrentsQueryModel query)
        {
            var torrentQuery = this.data.Torrents.AsQueryable();
            if (!String.IsNullOrEmpty(query.SearchTerm))
            {
                torrentQuery = torrentQuery.Where(x => x.Name.ToLower().Contains(query.SearchTerm.ToLower()));
            }
            if (!String.IsNullOrEmpty(query.Genre))
            {
                if (query.Genre != "All" )
                {
                    var genreID = this.data.Genres.Where(x => x.Name == query.Genre).Select(x => x.Id).FirstOrDefault();
                    torrentQuery = torrentQuery.Where(x => x.GenreId == genreID);
                }
            }
            if (!String.IsNullOrEmpty(query.Category))
            {
                if (query.Category !="All")
                {
                    var categoryID = this.data.Categories.Where(x => x.Name == query.Category).Select(x => x.Id).FirstOrDefault();

                    torrentQuery = torrentQuery.Where(x => x.CategoryId == categoryID);
                }
                
            }
            var categories = this.GetCategoriesForView();
            query.Categories = categories;

            var genres = this.GetGenresForView();
            query.Genres = this.GetGenresForView();

            var torrents = this.GetTorrents(query, torrentQuery);
            query.Torrents = torrents;

            var totalTorrents = this.data.Torrents.Count();
            query.TotalTorrents = totalTorrents;

            return View(query);
        }

        public IActionResult Torrent()
        {
            return View();
        }

        private ICollection<TorrentListingViewModel> GetTorrents(AllTorrentsQueryModel query,IQueryable<Torrent> torrentQuery)
        {
            var torrents = torrentQuery
                 .Skip((query.CurrentPage - 1) * AllTorrentsQueryModel.TorrentsPerPage)
                 .Take(AllTorrentsQueryModel.TorrentsPerPage).ProjectTo<TorrentListingViewModel>(mapper.ConfigurationProvider).ToList();

            return torrents;
        }

        private ICollection<string> GetCategoriesForView()
        {
            var categories = this.data.Categories.Select(x=>x.Name).ToList();


            return categories;
        }

        private ICollection<string> GetGenresForView()
        {
            var genres = this.data.Genres.Select(x=>x.Name).ToList();


            return genres;
        }

        
    }
}
