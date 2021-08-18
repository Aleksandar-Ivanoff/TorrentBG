namespace TorrentBG.Services.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Services.User.Models;
    using TorrentBG.Data.Models;
    public interface IUserService
    {
        UserProfileServiceModel GetCurrentProfile(string currentUser);
        void EditProfile(string userId,string userName, string FullName, string cityId, string phoneNumber,string email, string image);

        void DeleteProfile(string userId);
    }
}
