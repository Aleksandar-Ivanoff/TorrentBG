namespace TorrentBG.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using TorrentBG.Data;
    using TorrentBG.Data.Models;
    using TorrentBG.Models.CreateTorrents;

    public class AdministratorController : Controller
    {

        private readonly IMapper mapper;
        private readonly ApplicationDbContext data;
        public AdministratorController(IMapper mapper,ApplicationDbContext dbContext)
        {
            this.data = dbContext;
            this.mapper = mapper;
        }

        public IActionResult Index() => View();
       
        public IActionResult CreateMovie() => View(new CreateMovieFormModel { Categories=this.GetCategories(), Genres=this.GetGenres()});
        
        [HttpPost]
        public IActionResult CreateMovie(CreateMovieFormModel movieFormModel)
        {
            if (!ModelState.IsValid)
            {
               

                movieFormModel.Categories = this.GetCategories();
                movieFormModel.Genres = this.GetGenres();

                return View(movieFormModel);
            }

            var director = GetDirector(movieFormModel.DirectorName);

            movieFormModel.DirectorId = director.Id;


            var movie =this.mapper.Map<Torrent>(movieFormModel);

            

            this.data.Torrents.Add(movie);
            this.data.SaveChanges();

            return RedirectToAction("All", "Torrents");
        }

        public IActionResult CreateGame() => View(new CreateGameFormModel {Genres=this.GetGenres(),Categories=this.GetCategories()});

        [HttpPost]
        public IActionResult CreateGame(CreateGameFormModel gameModel)
        {
            if (!ModelState.IsValid)
            {
                return View(gameModel);
            }

            var developer = this.GetDeveloper(gameModel.DeveloperName);

            gameModel.DeveloperId = developer.Id;
          var game = this.mapper.Map<Torrent>(gameModel);

            this.data.Torrents.Add(game);
            this.data.SaveChanges();

            return RedirectToAction("All","Torrents");
        }


        public IActionResult CreateSeries() => View(new CreateSeriesFormModel {Categories=this.GetCategories(),Genres=this.GetGenres()});

        [HttpPost]
        public IActionResult CreateSeries(CreateSeriesFormModel seriesModel)
        {
            if (!ModelState.IsValid)
            {
                return View(seriesModel);
            }

            var director = this.GetDirector(seriesModel.DirectorName);

            seriesModel.DirectorId = director.Id;

          var series= this.mapper.Map<Torrent>(seriesModel);

            this.data.Torrents.Add(series);
            this.data.SaveChanges();

            return RedirectToAction("All", "Torrents");
            
        }

        private ICollection<TorrentsCategoryViewModel> GetCategories()
        {
            var categories = this.data.Categories.ProjectTo<TorrentsCategoryViewModel>(mapper.ConfigurationProvider)
                             .ToList();
                             

            return categories; 
        }

        private ICollection<TorrentsGenreViewModel> GetGenres()
        {
            var genres = this.data.Genres.ProjectTo<TorrentsGenreViewModel>(mapper.ConfigurationProvider).ToList();
                         

            return genres;
        }

        private Director GetDirector(string directorName)
        {
            var result = this.data.Directors.FirstOrDefault(x => x.FullName == directorName);

            if (result == null)
            {
                var director = new Director { FullName = directorName };

                this.data.Directors.Add(director);
                this.data.SaveChanges();

                return director;
            }
            return result;
        }

        private Developer GetDeveloper(string developerName)
        {
            var developer=this.data.Developers.FirstOrDefault(x => x.FullName == developerName);

            if (developer == null)
            {
                developer = new Developer { FullName = developerName };
                this.data.Developers.Add(developer);
                this.data.SaveChanges();
            }

            return developer;
        }
    }
}
