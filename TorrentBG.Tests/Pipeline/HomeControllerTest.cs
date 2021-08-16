namespace TorrentBG.Tests.Pipeline
{
    using System;
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using TorrentBG.App.Controllers;
    using TorrentBG.Data.Models;
    using System.Collections.Generic;
    using TorrentBG.Models.Home;
    using TorrentBG.Models;

    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnCorrectViewWithModel()
        => MyMvc
            .Pipeline()
            .ShouldMap("/")
            .To<HomeController>(x => x.Index())
            .Which(c => c.WithData(new Torrent()))
            .ShouldReturn()
            .View(v => v.WithModelOfType<List<NewestTorrentsViewModel>>());

        [Fact]
        public void IndexShouldReturnCorrectErrorView()
            =>MyMvc.
            Pipeline()
            .ShouldMap("/Home/Error")
            .To<HomeController>(c=>c.Error())
            .Which()
            .ShouldReturn()
            .View(v=>v.WithModelOfType<ErrorViewModel>());
            


       
    }
}
