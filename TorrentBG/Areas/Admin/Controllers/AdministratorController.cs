namespace TorrentBG.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TorrentBG.Areas.Admin.Models;
    using TorrentBG.Data;
    using TorrentBG.Data.Models;
    using TorrentBG.Models.CreateTorrents;
    using TorrentBG.Services.Category;
    using TorrentBG.Services.Developer;
    using TorrentBG.Services.Director;
    using TorrentBG.Services.Genre;
    using TorrentBG.Services.Torrent;
    using TorrentBG.Services.Torrent.Models;

    [Area(AdminConstants.AreaName)]
    [Authorize(Roles =AdminConstants.AdministratorRoleName)]
   
    public class AdministratorController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext data;
        private readonly ICategoryService categoryService;
        private readonly IGenreService genreService;
        private readonly IDeveloperService developerService;
        private readonly IDirectorService directorService;
        private readonly ITorrentService torrentService;

        public AdministratorController(IMapper mapper,ApplicationDbContext dbContext, ICategoryService categoryService, IGenreService genreService, IDeveloperService developerService,IDirectorService directorService, ITorrentService torrentService)
        {
            this.data = dbContext;
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.genreService = genreService;
            this.developerService = developerService;
            this.directorService = directorService;
            this.torrentService = torrentService;
        }

      
        public IActionResult CreateMovie() => View(new CreateMovieFormModel { Categories=this.categoryService.GetCategoriesForDropDown(), Genres=this.genreService.GetGenresForDropDown()});

      
        [HttpPost]
        public IActionResult CreateMovie(CreateMovieFormModel movieFormModel)
        {
            if (!ModelState.IsValid)
            {
                movieFormModel.Categories = this.categoryService.GetCategoriesForDropDown();
                movieFormModel.Genres = this.genreService.GetGenresForDropDown();

                return View(movieFormModel);
            }

            var movie =this.mapper.Map<CreateMovieFormServiceModel>(movieFormModel);
            this.torrentService.CreateMovie(movie);

            return RedirectToAction("All", "Torrents",new {area=""});
        }

      
        public IActionResult CreateGame() => View(new CreateGameFormModel {Genres=this.genreService.GetGenresForDropDown(),Categories=this.categoryService.GetCategoriesForDropDown()});

        
        [HttpPost]
        public IActionResult CreateGame(CreateGameFormModel gameModel)
        {
            if (!ModelState.IsValid)
            {
                gameModel.Categories = this.categoryService.GetCategoriesForDropDown();
                gameModel.Genres = this.genreService.GetGenresForDropDown();
                return View(gameModel);
            }

          var game = this.mapper.Map<CreateGameFormServiceModel>(gameModel);

          this.torrentService.CreateGame(game);

          return RedirectToAction("All","Torrents",new {area = "" });
        }

        public IActionResult CreateSeries() => View(new CreateSeriesFormModel {Categories=this.categoryService.GetCategoriesForDropDown(),Genres=this.genreService.GetGenresForDropDown()});
        
 
        [HttpPost]
        public IActionResult CreateSeries(CreateSeriesFormModel seriesModel)
        {
            if (!ModelState.IsValid)
            {
                seriesModel.Categories = this.categoryService.GetCategoriesForDropDown();
                seriesModel.Genres = this.genreService.GetGenresForDropDown();
                return View(seriesModel);
            }

             var series= this.mapper.Map<CreateSeriesFormServiceModel>(seriesModel);

            this.torrentService.CreateSeries(series);

            return RedirectToAction("All", "Torrents",new {area="" });
            
        }


        public IActionResult Edit(string Id)
        {
           var editModel= this.torrentService.GetEditModelForView(Id);

            var modelToSend = this.mapper.Map<EditTorrentFormModel>(editModel);

            modelToSend.Categories = this.categoryService.GetCategoriesForDropDown();
            modelToSend.Genres = this.genreService.GetGenresForDropDown();

            return View(modelToSend);
        }

        
        [HttpPost]
        public IActionResult Edit(EditTorrentFormModel editModel)
        {
            var mapped=this.mapper.Map<EditTorrentFormServiceModel>(editModel);
            this.torrentService.Edit(mapped);
            return RedirectToAction("All","Torrents",new {area="" });
        }

    
        [HttpPost]
        public IActionResult Delete(string Id)
        {
            //TODO
            return View();
        }

       

    }
}
