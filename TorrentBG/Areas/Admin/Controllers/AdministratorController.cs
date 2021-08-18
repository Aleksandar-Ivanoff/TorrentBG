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
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Hosting;

    [Area(AdminConstants.AreaName)]
    [Authorize(Roles =AdminConstants.AdministratorRoleName)]
   
    public class AdministratorController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;
        private readonly IGenreService genreService;
        private readonly IDeveloperService developerService;
        private readonly IDirectorService directorService;
        private readonly ITorrentService torrentService;

        public AdministratorController(IMapper mapper,ApplicationDbContext dbContext, ICategoryService categoryService,
            IGenreService genreService, IDeveloperService developerService,IDirectorService directorService,
            ITorrentService torrentService,IWebHostEnvironment webHostEnvironment)
            
        {
            this.data = dbContext;
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.genreService = genreService;
            this.developerService = developerService;
            this.directorService = directorService;
            this.torrentService = torrentService;
            this.webHostEnvironment = webHostEnvironment;
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

            movie.ImagePath = ConvertImageFile(movieFormModel.Image);
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
            string filePath = ConvertImageFile(gameModel.Image);

            var game = this.mapper.Map<CreateGameFormServiceModel>(gameModel);
            game.ImagePath = filePath;

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

            series.ImagePath = ConvertImageFile(seriesModel.Image);

            this.torrentService.CreateSeries(series);

            return RedirectToAction("All", "Torrents",new {area="" });
            
        }


        public IActionResult Edit(string Id)
        {
           var editModel= this.torrentService.GetEditModelForView(Id);

            var modelToSend = this.mapper.Map<EditTorrentFormModel>(editModel);

            modelToSend.ImagePath = editModel.ImagePath;
            modelToSend.Categories = this.categoryService.GetCategoriesForDropDown();
            modelToSend.Genres = this.genreService.GetGenresForDropDown();

            return View(modelToSend);
        }

        
        [HttpPost]
        public IActionResult Edit(EditTorrentFormModel editModel)
        {
            
            var mapped=this.mapper.Map<EditTorrentFormServiceModel>(editModel);

            mapped.ImagePath= ConvertImageFile(editModel.Image);
            this.torrentService.Edit(mapped);

            return RedirectToAction("All","Torrents",new {area="" });
        }

    
       
        public IActionResult Delete(string Id)
        {

            this.torrentService.DeleteTorrent(Id);

            return RedirectToAction("All","Torrents",new {area = ""});
        }


        private string ConvertImageFile(IFormFile formFile)
        {
            try
            {   
                string dir = Path.Combine(webHostEnvironment.WebRootPath, "img");
                
                string filePath = Path.Combine(dir, formFile.FileName);

                formFile.CopyTo(new FileStream(filePath, FileMode.Create));

                
                return formFile.FileName;
            }
            catch (Exception)
            {

                return null;
            }
           
        }
    }
}
