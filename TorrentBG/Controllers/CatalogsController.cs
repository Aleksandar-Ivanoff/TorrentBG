using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace TorrentBG.App.Controllers
{
    [Authorize]
    public class CatalogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
