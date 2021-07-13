namespace TorrentBG.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using TorrentBG.Models.CreateTorrents;

    public class AdministratorController : Controller
    {

        public AdministratorController()
        {

        }

        public IActionResult Index() => View();
       
        public IActionResult CreateMovie() => View();
        
        [HttpPost]
        public IActionResult CreateMovie(CreateMovieFormModel movieFormModel)
        {
            if (!ModelState.IsValid)
            {
                if (movieFormModel.Length == 0)
                {
                    ModelState.AddModelError(nameof(movieFormModel.Length), "Please enter the length.");
                }
                if (movieFormModel.Year == 0)
                {
                    ModelState.AddModelError(nameof(movieFormModel.Year), "Please enter the year.");
                }
                return View(movieFormModel);
            }

            return RedirectToAction("/Home/Index");
        }

        public IActionResult CreateGame() => View();

        [HttpPost]
        public IActionResult CreateGame(CreateGameFormModel gameModel)
        {
            //TODO
            return View();
        }


        public IActionResult CreateSeries() => View();

        public IActionResult CreateSeries(CreateSeriesFormModel seriesModel)
        {
            //TODO
            return View(seriesModel);
        }

        //private IEnumerable<TorrentsCategoryViewModel> GetCategories()
        //{

        //}
    }
}
