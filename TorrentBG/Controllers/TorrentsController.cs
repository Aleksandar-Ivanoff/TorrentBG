using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorrentBG.App.Controllers
{
    public class TorrentsController : Controller
    {
        public IActionResult All(string searchTerm)
        {
            if (!String.IsNullOrEmpty(searchTerm))
            {

            }
            return View();
        }

        public IActionResult Torrent()
        {
            return View();
        }
    }
}
