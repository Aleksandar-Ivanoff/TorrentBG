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
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TorrentBG.Data;
    using TorrentBG.Data.Models;
    using TorrentBG.Models.UserProfile;
    using TorrentBG.Services.City;
    using TorrentBG.Services.User;

    [Authorize]
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly ApplicationDbContext data;
        private readonly ICityService cityService;
        private readonly SignInManager<User> signInManager;

        public UserController(IMapper mapper,ApplicationDbContext dbContext,IUserService userService, ICityService cityService,SignInManager<User> signInManager)
        {
            this.mapper = mapper;
            this.data = dbContext;
            this.userService = userService;
            this.cityService = cityService;
            this.signInManager = signInManager;
        }
        
        public IActionResult Profile()
        {
            var currentUser = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = this.userService.GetCurrentProfile(currentUser);

            var userModel = this.mapper.Map<ProfileViewModel>(user);
           

            return View(userModel);
        }
        
        public IActionResult Edit(string Id)
        {
            var profile = this.userService.GetCurrentProfile(Id);


            var profileViewModel = this.mapper.Map<EditProfileFormModel>(profile);
            profileViewModel.Cities = this.cityService.GetCities().ProjectTo<CitiesListingViewModel>(this.mapper.ConfigurationProvider).ToList();

            return View(profileViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditProfileFormModel profileModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(profileModel);
            }
            if (profileModel.CityId == "None")
            {
                profileModel.CityId = null;
            }

            this.userService.EditProfile(userId:profileModel.Id,FullName: profileModel.FullName, email:profileModel.Email, phoneNumber:profileModel.PhoneNumber, cityId:profileModel.CityId, userName:profileModel.UserName);
            
            return RedirectToAction("Profile", "User");

        }

       
        public IActionResult Delete(string Id)
        {
            this.userService.DeleteProfile(Id);

            this.signInManager.SignOutAsync();  
            return   RedirectToAction("Index", "Home");
        }

    }
}
