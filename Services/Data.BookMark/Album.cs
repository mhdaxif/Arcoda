using Data.MusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BookMark
{
    public class Album : Entity
    {
        public string Title { get; set; }
        public List<Song> Songs { get; set; }
    }
}
