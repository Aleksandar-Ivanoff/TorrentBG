namespace TorrentBG.MappingConfiguration
{
    using AutoMapper;
    using TorrentBG.Areas.Admin.Models;
    using TorrentBG.Data.Models;
    using TorrentBG.Models.CreateTorrents;
    using TorrentBG.Models.Developer;
    using TorrentBG.Models.Director;
    using TorrentBG.Models.Home;
    using TorrentBG.Models.Torrents;
    using TorrentBG.Models.UserProfile;
    using TorrentBG.Services.City.Models;
    using TorrentBG.Services.Developer.Models;
    using TorrentBG.Services.Director.Models;
    using TorrentBG.Services.Torrent.Models;
    using TorrentBG.Services.User.Models;

    public class TorrentBGProfile : Profile
    {
        public TorrentBGProfile()
        {
            //CreateGame
            this.CreateMap<CreateGameFormModel, CreateGameFormServiceModel>();

            //EditTorrent
            this.CreateMap<EditTorrentFormServiceModel, EditTorrentFormModel>();
            this.CreateMap<EditTorrentFormServiceModel, EditTorrentFormModel>().ReverseMap();

            //CreateMovie
            this.CreateMap<CreateMovieFormModel,CreateMovieFormServiceModel>().ForMember(x => x.Name, y => y.MapFrom(x => x.Name)).ForMember(x => x.GenreId, y => y.MapFrom(x => x.GenreId)).ForMember(x => x.DirectorId, y => y.MapFrom(x => x.DirectorId));

            //CreateSeries
            this.CreateMap<CreateSeriesFormModel, CreateSeriesFormServiceModel>();


            //Categories

            this.CreateMap<Category, TorrentsCategoryViewModel>();
           

            //Genres
            this.CreateMap<Genre, TorrentsGenreViewModel>();
            

            //Torrents
            this.CreateMap<Torrent, TorrentListingViewModel>();

            this.CreateMap<TorrentServiceModel, TorrentDetailsViewModel>()
                .ForMember(x => x.DirectorName, y => y.MapFrom(x => x.DirectorName))
                .ForMember(x => x.DeveloperName, y => y.MapFrom(x => x.DeveloperName))
                .ForMember(x => x.CategoryName, y => y.MapFrom(x => x.CategoryName))
                .ForMember(x => x.CategoryName, y => y.MapFrom(x => x.CategoryName));
                
          

            this.CreateMap<AllTorrentServiceModel, AllTorrentsQueryModel>();

            //UserProfile
            this.CreateMap<UserProfileServiceModel, ProfileViewModel>();
            this.CreateMap<UserProfileServiceModel, EditProfileFormModel>();
            this.CreateMap<UserProfileServiceModel, EditProfileFormModel>().ReverseMap();



            //Cities
            this.CreateMap<CityListServiceModel, CitiesListingViewModel>();


            //HomeTorrents
            this.CreateMap<NewestTorrentsServiceModel, NewestTorrentsViewModel>();


            //Director
            this.CreateMap<DirectorServiceModel, DirectorViewModel>();

            //Developer
            this.CreateMap<DeveloperServiceModel, DeveloperViewModel>();
        }
        
    }
}
