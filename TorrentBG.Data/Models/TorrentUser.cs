namespace TorrentBG.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class TorrentUser
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string  UserId { get; set; }
        public User User { get; set; }

        public string TorrentId { get; set; }
        public Torrent Torrent { get; set; }
    }
}
