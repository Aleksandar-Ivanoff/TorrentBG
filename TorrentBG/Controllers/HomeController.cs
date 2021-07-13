namespace TorrentBG.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TorrentBG.Models;
    using TorrentBG.Models.CreateTorrents;

    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

       
        public IActionResult Index() => View();    }
}
