using Data.Shared;
using System.Collections.Generic;

namespace Data.MusicStore
{
    // Genre(ROCK, HIP HOP, ELECTRONIC)
    public partial class Genre : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Album> Albums { get; set; }
    }

}
