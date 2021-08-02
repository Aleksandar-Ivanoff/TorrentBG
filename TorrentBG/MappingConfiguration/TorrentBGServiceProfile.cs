namespace TorrentBG.MappingConfiguration
{
   
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using TorrentBG.Data.Models;
    using TorrentBG.Services.User.Models;

    public class TorrentBGServiceProfile : Profile
    {
        public TorrentBGServiceProfile()
        {
            //Users

            this.CreateMap<User, UserProfileServiceModel>();
        }
    }
}
