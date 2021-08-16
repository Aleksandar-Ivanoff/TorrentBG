namespace TorrentBG.Tests.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Areas.Admin.Controllers;
    using TorrentBG.Areas.Admin.Models;
    using TorrentBG.Controllers;
    using TorrentBG.Data.Models;
    using TorrentBG.Models.Torrents;
    using TorrentBG.Services.Torrent.Models;
    using TorrentBG.Tests.Mocks;
    using Xunit;

    public class AdminControllerTest
    {
        //Controller
        [Fact]
        public void AdminControllerShouldBeForAdminUsers()
            => MyController<AdministratorController>
            .Instance()
            .ShouldHave()
            .Attributes(C => C.RestrictingForAuthorizedRequests());

        //Create Movie
        [Fact]
        public void GetCreateMovieViewShouldWork()
            => MyController<AdministratorController>
            .Instance()
            .Calling(c => c.CreateMovie())
            .ShouldReturn()
            .View(v => v.WithModelOfType<CreateMovieFormModel>());

        [Theory]
        [InlineData("PetarPetrov", "453a8048-ab97-415b-b70f-7c8b36ec8be0","Boratttt","The best movie",2015,30,"Pesho,Mariyka", "c1648f62-b02a-400d-9c79-ffe836c56d94", "9f902e1c-de4c-4346-ad4b-a123da8fa156")]
        public void PostCreateMovieShouldWork(string directorName, string directorId,string movieName, string description, int year,int length,string mainActors,string categoryId,string genreId)
        {
            //var director = DirectorMock.Instance;

            MyController<AdministratorController>
              .Instance(c => c.WithUser("Admin", "Administrator"))
              .Calling(c => c.CreateMovie(new CreateMovieFormModel
              {
                  Name = movieName,
                  DirectorId = directorId,
                  DirectorName = directorName,
                  Description = description,
                  Year = year,
                  Length = length,
                  MainActors = mainActors,
                  CategoryId = categoryId,
                  GenreId = genreId,
              }))
              .ShouldHave()
              .ActionAttributes(a => a.
                  RestrictingForHttpMethod(HttpMethod.Post))
              .ValidModelState()
              .Data(d => d
                 .WithSet<Torrent>(t => t
                      .Any(d => d.Name == movieName && d.Year == year && d.Length == length &&
                                                            d.DirectorId == directorId &&
                                                            d.GenreId == genreId &&
                                                            d.CategoryId == categoryId)))
              .AndAlso()
              .ShouldReturn()
              .Redirect(r => r
              .To<TorrentsController>(c => c.All(With.Any<AllTorrentsQueryModel>())));

        }


        

        

        //CreateSeries
        [Fact]
        public void GetCreateSeriesViewShouldWork()
           => MyController<AdministratorController>
           .Instance()
           .Calling(c => c.CreateSeries())
           .ShouldReturn()
           .View(v => v.WithModelOfType<CreateSeriesFormModel>());



        //Edit

        [Fact]
        [InlineData("")]
        public void GetEditViewShouldWork()
        {

        }
         
    }
}
