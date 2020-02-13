using Data.Shared;
using System.Collections.Generic;

namespace Data.MusicStore
{
    // Album
    public class Album : Entity
    {
        public string Title { get; set; }
        public string Brief { get; set; }
        public string AlbumArtUrl { get; set; }

        public int? GenreId { get; set; }
        public int? ArtistId { get; set; }

        public Genre Genre { get; set; }
        public Artist Artist { get; set; }
        public List<Song> Songs { get; set; }
    }

}
