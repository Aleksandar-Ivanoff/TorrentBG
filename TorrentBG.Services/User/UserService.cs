namespace TorrentBG.Services.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Data;
    using TorrentBG.Services.City;
    using TorrentBG.Services.User.Models;
    using TorrentBG.Data.Models;
    using TorrentBG.Services.Common;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext data;
        private readonly ICityService cityService;
        public UserService(ApplicationDbContext dbContext,ICityService cityService)
        {
            this.data = dbContext;
            this.cityService = cityService;
        }

        public void DeleteProfile(string userId)
        {
            var profileToDelete = this.data.Users.Find(userId);

            this.data.Users.Remove(profileToDelete);
            this.data.SaveChanges();
        }

        public void EditProfile(string userId,string userName, string FullName, string cityId, string phoneNumber, string email,string image)
        {

            var editedUser = this.data.Users.Find(userId);

            if (image != null)
            {
                editedUser.Image = image;
            }

            editedUser.CityId = cityId;
            editedUser.FullName = FullName;
            editedUser.Email = email;
            editedUser.PhoneNumber = phoneNumber;
            editedUser.UserName = userName;

            this.data.Users.Update(editedUser);
            this.data.SaveChanges();
        }

        public UserProfileServiceModel GetCurrentProfile(string userId)
        {
            var userProfile = this.data.Users.Where(x => x.Id == userId).FirstOrDefault();

            if (userProfile == null)
            {
                return null;
            }

            return new UserProfileServiceModel
            {
                Id = userProfile.Id,
                City = this.cityService.GetCityNameByUserId(userProfile.Id),
                Email=userProfile.Email,
                FullName=userProfile.FullName,
                PhoneNumber = userProfile.PhoneNumber,
                UserName=userProfile.UserName,
                ImagePath=ImageConverter.GetImagePathToShow(userProfile.Image)

            };
 
        }
    }
}
