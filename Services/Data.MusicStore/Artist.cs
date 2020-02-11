using System.Collections.Generic;

namespace Data.MusicStore
{
    // Artist
    public class Artist : Entity
    {
        public string Name { get; set; }

        public List<Album> Albums { get; set; }
        public List<Song> Songs { get; set; }
    }

}
