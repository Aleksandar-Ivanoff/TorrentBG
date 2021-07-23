﻿namespace TorrentBG.MappingConfiguration
{
    using AutoMapper;
    using TorrentBG.Data.Models;
    using TorrentBG.Models.CreateTorrents;
    using TorrentBG.Models.Torrents;
    using TorrentBG.Models.UserProfile;

    public class TorrentBGProfile : Profile
    {
        public TorrentBGProfile()
        {
            //CreateGame
            this.CreateMap<CreateGameFormModel, Torrent>();
            

            //CreateMovie
            this.CreateMap<CreateMovieFormModel,Torrent>().ForMember(x => x.Name, y => y.MapFrom(x => x.Name)).ForMember(x => x.GenreId, y => y.MapFrom(x => x.GenreId)).ForMember(x => x.DirectorId, y => y.MapFrom(x => x.DirectorId));

            //CreateSeries
            this.CreateMap<CreateSeriesFormModel, Torrent>();


            //Categories

            this.CreateMap<Category, TorrentsCategoryViewModel>();
           

            //Genres
            this.CreateMap<Genre, TorrentsGenreViewModel>();
            

            //Torrents
            this.CreateMap<Torrent, TorrentListingViewModel>();

            //UserProfile
            this.CreateMap<User, ProfileViewModel>();
            this.CreateMap<User, EditProfileFormModel>();
            this.CreateMap<EditProfileFormModel, User>();


            //Cities
            this.CreateMap<City, CitiesListingViewModel>();
        }
        
    }
}
