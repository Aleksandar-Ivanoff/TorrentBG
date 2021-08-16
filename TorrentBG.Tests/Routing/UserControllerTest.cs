namespace TorrentBG.Tests.Routing
{
    using MyTested.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Controllers;
    using TorrentBG.Models.UserProfile;
    using Xunit;

    public class UserControllerTest
    {
        [Fact]
        public void ProfileRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/User/Profile")
            .To<UserController>(c => c.Profile());

        [Theory]
        [InlineData("da62e011-5c37-4ee2-880c-2d0f8138cbf3")]
        public void GetEditRouteShouldBeMapped(string id)
            => MyRouting.
            Configuration()
            .ShouldMap($"/User/Edit/{id}")
            .To<UserController>(c => c.Edit(id));


        [Fact]
        public void PostEditRouteShouldBeMapped()
        => MyRouting
            .Configuration()
            .ShouldMap(r => r
            .WithPath("/User/Edit")
            .WithMethod(HttpMethod.Post))
            .To<UserController>(c => c.Edit(With.Any<EditProfileFormModel>()));

        
           
    }
}
