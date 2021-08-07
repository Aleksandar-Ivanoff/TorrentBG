﻿namespace TorrentBG.Services.Torrent
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
    using TorrentBG.Services.Developer;
    using TorrentBG.Services.Director;

    public class TorrentService : ITorrentService
    {
        private readonly ApplicationDbContext data;
        private readonly ICategoryService categoryService;
        private readonly IGenreService genreService;
        private readonly IMapper mapper;
        private readonly IDeveloperService developerService;
        private readonly IDirectorService directorService;

        public TorrentService(ApplicationDbContext data, ICategoryService categoryService, IGenreService genreService,IMapper mapper, IDeveloperService developerService, IDirectorService directorService)
        {
            this.data = data;
            this.categoryService = categoryService;
            this.genreService = genreService;
            this.mapper = mapper;
            this.developerService = developerService;
            this.directorService = directorService;

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
                Categories = this.categoryService.GetCategoriesNameModel(),
                Genres = this.genreService.GetGenresNameForQuery(),
                SearchTerm = searchTerm,
                TotalTorrents = torrentQuery.Count(),
                Torrents = GetTorrents(torrentQuery.Skip((currentPage - 1) * torrentsPerPage).Take(torrentsPerPage)),
                CurrentPage=currentPage,
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

        public IQueryable<NewestTorrentsServiceModel> GetNewestTorrents()
        {
             return this.data.Torrents.OrderByDescending(x => x.Id).Select(x=> new NewestTorrentsServiceModel
            {
                Id=x.Id,
                Description=x.Description,
                Name=x.Name,
            });
        }

        public void CreateGame(CreateGameFormServiceModel gameModel)
        {
            var torrent = new Torrent
            {
                Name= gameModel.Name,
                InstallInstructions= gameModel.InstallInstructions,
                DeveloperId=this.developerService.GetDeveloper(gameModel.DeveloperName).Id,
                CategoryId=gameModel.CategoryId,
                GenreId=gameModel.GenreId,
                Description=gameModel.Description,
                Year=gameModel.Year,
                Image=gameModel.Image,

            };

            this.data.Torrents.Add(torrent);
            this.data.SaveChanges();
        }

        public void CreateMovie(CreateMovieFormServiceModel movieModel)
        {
            var torrent = new Torrent
            {
                Name = movieModel.Name,
                MainActors = movieModel.MainActors,
                DirectorId = this.directorService.GetDirector(movieModel.DirectorName).Id,
                CategoryId = movieModel.CategoryId,
                GenreId = movieModel.GenreId,
                Description = movieModel.Description,
                Year = movieModel.Year,
                Image = movieModel.Image,
                Length=movieModel.Length

            };

            this.data.Torrents.Add(torrent);
            this.data.SaveChanges();
        }
        public void CreateSeries(CreateSeriesFormServiceModel seriesModel)
        {
            var torrent = new Torrent
            {
                Name = seriesModel.Name,
                MainActors = seriesModel.MainActors,
                DirectorId = this.directorService.GetDirector(seriesModel.DirectorName).Id,
                CategoryId = seriesModel.CategoryId,
                GenreId = seriesModel.GenreId,
                Description = seriesModel.Description,
                Year = seriesModel.Year,
                Image = seriesModel.Image,
                Length = seriesModel.Length

            };

            this.data.Torrents.Add(torrent);
            this.data.SaveChanges();
        }

        public EditTorrentFormServiceModel GetEditModelForView(string torrentId)
        {
            var torrent = this.data.Torrents
                .Include(x=>x.Genre)
                .Include(x=>x.Category)
                .Where(x => x.Id == torrentId)
                .FirstOrDefault();

            if (torrent.Category.Name == "Games")
            {
                return IfTorrentIsAGame(torrent);
            }
            else
            {
                return IfTorrentIsMovieOrSeries(torrent);
            }
        }

        public void Edit(EditTorrentFormServiceModel editModel)
        {
            var torrent = this.data.Torrents.Where(x => x.Id == editModel.Id).FirstOrDefault();


            torrent.Name = editModel.Name;
            torrent.Description = editModel.Description;
            torrent.Year = editModel.Year;
            torrent.GenreId = editModel.GenreId;
            torrent.CategoryId = editModel.CategoryId;


            editModel.CategoryName = this.categoryService.GetCategoryNameById(editModel.CategoryId);

            if (editModel.CategoryName == "Games")
            {
                torrent.DeveloperId = this.developerService.GetDeveloper(editModel.DeveloperName).Id;
                torrent.InstallInstructions = editModel.InstallInstructions;
                
            }
            else 
            {
                torrent.DirectorId = this.directorService.GetDirector(editModel.DirectorName).Id;
                torrent.Length = editModel.Length;
                torrent.MainActors = editModel.MainActors;
            }

            this.data.Torrents.Update(torrent);
            this.data.SaveChanges();

            
        }

        private EditTorrentFormServiceModel IfTorrentIsAGame(Torrent torrent)
        {
            var gameTorrent = new EditTorrentFormServiceModel
            {
                Name = torrent.Name,
                InstallInstructions = torrent.InstallInstructions,
                Year = torrent.Year,
                Image = torrent.Image,
                Description = torrent.Description,
                DeveloperId = torrent.DeveloperId,
                DeveloperName = this.developerService.GetDeveloperName(torrent.DeveloperId),
                CategoryId=torrent.CategoryId,
                GenreId=torrent.GenreId,
                GenreName = torrent.Genre.Name,
                CategoryName = torrent.Category.Name,
            };

            return gameTorrent;
        }
        private EditTorrentFormServiceModel IfTorrentIsMovieOrSeries(Torrent torrent)
        {
            var movieTorrent = new EditTorrentFormServiceModel
            {
                Name = torrent.Name,
                MainActors = torrent.MainActors,
                Length=torrent.Length,
                Year = torrent.Year,
                Image = torrent.Image,
                Description = torrent.Description,
                DirectorId = torrent.DirectorId,
                DirectorName = this.directorService.GetDirectorName(torrent.DirectorId),
                CategoryId = torrent.CategoryId,
                GenreId = torrent.GenreId,
                GenreName= torrent.Genre.Name,
                CategoryName=torrent.Category.Name,

            };

            return movieTorrent;
        }

       
    }
}
