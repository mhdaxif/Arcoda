using Data.Shared; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BookMark
{
    public class AlbumBookMark : Entity
    {
        public int AlbumId { get; set; }
        public int? ApplicationUserId { get; set; } 

        public Album Album { get; set;}
        public ApplicationUser ApplicationUser { get; set;}
    }
}
