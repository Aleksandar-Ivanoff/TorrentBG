﻿namespace TorrentBG.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ErrorController : Controller
    {
        public IActionResult OOPS() => View();
    }
}
