using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Shared;

namespace Data.MusicStore
{
    // Song 
    public partial class Song : Entity
    {
        public string Name { get; set; }
        public string Brief { get; set; }
        public string Description { get; set; }
        public string SongContent { get; set; } // lyric

        public int? AlbumId { get; set; }
        public int? ArtistId { get; set; }

        public Album Album { get; set; }
        public Artist Artist { get; set; }
    }

}
