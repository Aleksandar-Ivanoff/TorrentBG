namespace TorrentBG.Tests.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Areas.Admin.Controllers;
    using Xunit;

    public  class AdminHomeControllerTest
    {
        [Fact]
        public void AdminIndexViewShouldWork()
            => MyController<HomeController>
            .Instance()
            .Calling(c => c.Index())
            .ShouldReturn()
            .View();
    }
}
