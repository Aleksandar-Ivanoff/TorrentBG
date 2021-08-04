namespace TorrentBG.Services.Torrent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Data;
    using TorrentBG.Services.Category;
    using TorrentBG.Services.Genre;
    using TorrentBG.Services.Torrent.Models;
    using TorrentBG.Data.Models;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    public class TorrentService : ITorrentService
    {
        private readonly ApplicationDbContext data;
        private readonly ICategoryService categoryService;
        private readonly IGenreService genreService;
        private readonly IMapper mapper;

        public TorrentService(ApplicationDbContext data, ICategoryService categoryService, IGenreService genreService,IMapper mapper)
        {
            this.data = data;
            this.categoryService = categoryService;
            this.genreService = genreService;
            this.mapper = mapper;
        }
        public AllTorrentServiceModel All(string searchTerm, string genre, string category, int currentPage, int torrentsPerPage)
        {
            
            var torrentQuery = this.data.Torrents.AsQueryable();

            if (!String.IsNullOrEmpty(searchTerm))
            {
                torrentQuery = torrentQuery.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }
            if (!String.IsNullOrEmpty(genre))
            {
                if (genre != "All")
                {
                    var genreID = this.genreService.GetGenreIdByName(genre);
                    torrentQuery = torrentQuery.Where(x => x.GenreId == genreID);
                }
            }
            if (!String.IsNullOrEmpty(category))
            {
                if (category != "All")
                {
                    var categoryID = this.categoryService.GetCategoryIdByName(category);

                    torrentQuery = torrentQuery.Where(x => x.CategoryId == categoryID);
                }
            }

            return new AllTorrentServiceModel
            {
                Categories = this.categoryService.GetCategoriesForView(),
                Genres = this.genreService.GetGenresForQuery(),
                SearchTerm = searchTerm,
                TotalTorrents = torrentQuery.Count(),
                Torrents = GetTorrents(torrentQuery.Skip((currentPage - 1) * torrentsPerPage).Take(torrentsPerPage)),
            };
        }
        private static IEnumerable<TorrentListServiceModel> GetTorrents(IQueryable<Torrent> torrentQuery)
        {
            var torrents = torrentQuery
                .Select(x => new TorrentListServiceModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    Image = x.Image,
                    Name = x.Name,

                }).ToList();

            return torrents;
        }

        public Torrent GetTorrentById(string torrentId) => this.data.Torrents.Include(x => x.Category).Include(x => x.Developer).Include(x => x.Director).FirstOrDefault(x => x.Id == torrentId);


    }
}
