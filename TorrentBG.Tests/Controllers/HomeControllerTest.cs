namespace TorrentBG.Tests.Controllers
{
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.App.Controllers;
    using TorrentBG.Data.Models;
    using TorrentBG.Models.Home;
    using Xunit;

    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnCorrectViewWithModel()
        => MyController<HomeController>
            .Instance(c => c.WithData(Enumerable.Range(0, 3).Select(x => new Torrent { })))
            .Calling(c => c.Index())
            .ShouldReturn()
            .View(c => c.WithModelOfType<List<NewestTorrentsViewModel>>()
            .Passing(model => model.Should().HaveCount(3)));

        [Fact]
        public void IndexShouldReturnCorrectViewWithAdmin()
            => MyController<HomeController>
            .Instance(c => c.WithUser("Admin", "Administrator"))
            .Calling(c => c.Index())
            .ShouldReturn()
            .View();
            

        
    }
}
