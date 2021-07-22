namespace TorrentBG.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using TorrentBG.Data;
    using TorrentBG.Models.UserProfile;

    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext data;

        public UserController(IMapper mapper,ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.data = dbContext;
        }
        public IActionResult Profile()
        {
            var user = this.data.Users.FirstOrDefault(x => x.Id == this.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var userModel = this.mapper.Map<ProfileViewModel>(user);
            return View(userModel);
        }
    }
}
