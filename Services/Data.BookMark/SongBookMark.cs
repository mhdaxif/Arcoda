using Data.MusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BookMark
{
    public class SongBookMark : Entity
    {
        public int SongId { get; set; }
        public int? UserId { get; set; }

        public Song Song { get; set; }
        public User User { get; set; }
    }
}
