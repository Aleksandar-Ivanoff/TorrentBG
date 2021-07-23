namespace TorrentBG.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TorrentBG.Data;
    using TorrentBG.Data.Models;
    using TorrentBG.Models.UserProfile;


    [Authorize]
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
            var userCity = this.data.Cities.Where(x => x.Id == user.CityId).FirstOrDefault();

            userModel.City = userCity.Name;
            return View(userModel);
        }
        
        public IActionResult Edit(string Id)
        {
            var profile = this.data.Users.Find(Id);


            var profileViewModel = this.mapper.Map<EditProfileFormModel>(profile);
            profileViewModel.Cities = this.GetCities();

            return View(profileViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditProfileFormModel profileModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(profileModel);
            }

            //var cityId = this.data.Cities.Where(x => x.Name == profileModel.City).Select(x => x.Id).ToString();

            if (!String.IsNullOrEmpty(profileModel.CityId))
            {
                //ToDo
            }
            var profileToEdit = this.data.Users.Find(profileModel.Id);

            profileToEdit = this.mapper.Map(profileModel, profileToEdit);

            this.data.Users.Update(profileToEdit);
            this.data.SaveChanges();
            return RedirectToAction("Profile", "User");

        }

        private IEnumerable<CitiesListingViewModel> GetCities()
        {
            return this.data.Cities.ProjectTo<CitiesListingViewModel>(mapper.ConfigurationProvider);
        }
    }
}
