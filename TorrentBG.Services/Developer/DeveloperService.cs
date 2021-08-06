namespace TorrentBG.Services.Developer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Data;
    using TorrentBG.Data.Models;
    using TorrentBG.Services.Developer.Models;


    public class DeveloperService : IDeveloperService
    {
        private readonly ApplicationDbContext data;
        public DeveloperService(ApplicationDbContext data)
        {
            this.data = data;
        }
        public DeveloperServiceModel GetDeveloper(string name)
        {
            var result = this.data.Developers.FirstOrDefault(x => x.FullName == name);

            if (result == null)
            {
                var developer = new Developer { FullName = name };

                this.data.Developers.Add(developer);
                this.data.SaveChanges();

                return new DeveloperServiceModel { Id = developer.Id, Name = developer.FullName };
            }
            return new DeveloperServiceModel {Id=result.Id, Name=result.FullName };
        }
    }
}
