using Data.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BookMark
{
    public class Song : Entity
    {
        public string Name { get; set; }
        public string Brief { get; set; }

        public int? AlbumId { get; set; }
    }
}
