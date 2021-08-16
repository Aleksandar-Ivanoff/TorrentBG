namespace TorrentBG.Tests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TorrentBG.Data.Models;

    public static class DirectorMock
    {
        public static Director Instance 
        {
            get
            {
                return new Director { Id = "453a8048-ab97-415b-b70f-7c8b36ec8be0", FullName = "PetarPetrov" };
            }
        }
    }
}
