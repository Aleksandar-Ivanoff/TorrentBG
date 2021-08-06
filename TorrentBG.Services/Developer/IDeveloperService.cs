namespace TorrentBG.Services.Developer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Data.Models;
    using TorrentBG.Services.Developer.Models;

    public interface IDeveloperService
    {
        DeveloperServiceModel GetDeveloper(string name);
    }
}
