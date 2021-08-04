﻿namespace TorrentBG.MappingConfiguration
{
    using AutoMapper;
    using TorrentBG.Data.Models;
    using TorrentBG.Models.CreateTorrents;
    using TorrentBG.Models.Home;
    using TorrentBG.Models.Torrents;
    using TorrentBG.Models.UserProfile;
    using TorrentBG.Services.City.Models;
    using TorrentBG.Services.Torrent.Models;
    using TorrentBG.Services.User.Models;

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
            this.CreateMap<Torrent, TorrentDetailsViewModel>()
                .ForMember(x=>x.Developer,y=>y.MapFrom(y=>y.Developer.FullName))
                .ForMember(x=>x.Director,y=>y.MapFrom(y=>y.Director.FullName));

            this.CreateMap<AllTorrentServiceModel, AllTorrentsQueryModel>();

            //UserProfile
            this.CreateMap<UserProfileServiceModel, ProfileViewModel>();
            this.CreateMap<UserProfileServiceModel, EditProfileFormModel>();
            this.CreateMap<UserProfileServiceModel, EditProfileFormModel>().ReverseMap();



            //Cities
            this.CreateMap<CityListServiceModel, CitiesListingViewModel>();



            //HomeTorrents
            this.CreateMap<Torrent, NewestTorrentsViewModel>();
        }
        
    }
}
