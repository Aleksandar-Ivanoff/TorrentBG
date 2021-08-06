namespace TorrentBG.Services.Director
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Data;
    using TorrentBG.Data.Models;
    using TorrentBG.Services.Director.Models;

    public class DirectorService : IDirectorService
    {
        private readonly ApplicationDbContext data;
        public DirectorService(ApplicationDbContext dbContext)
        {
            this.data = dbContext;
        }
        public DirectorServiceModel GetDirector(string name)
        {
            var result = this.data.Directors.FirstOrDefault(x => x.FullName == name);

            if (result == null)
            {
                var director = new Director { FullName = name };

                this.data.Directors.Add(director);
                this.data.SaveChanges();

                return new DirectorServiceModel { Id = director.Id, Name = director.FullName };
            }
            return new DirectorServiceModel {Id= result.Id, Name=result.FullName };
        }
    }
}
