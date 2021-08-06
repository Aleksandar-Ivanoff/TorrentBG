namespace TorrentBG.Services.Director
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Services.Director.Models;

    public interface IDirectorService
    {
        DirectorServiceModel GetDirector(string name); 
    }
}
