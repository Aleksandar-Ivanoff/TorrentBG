namespace TorrentBG.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeveloperController : Controller
    {
        public DeveloperController()
        {
        }

        public IActionResult Torrents(string Id)
        {
            return View();
        }
    }
}
