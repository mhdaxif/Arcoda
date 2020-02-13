using Data.BookMark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.BookMark.Data
{
    public static class MockDataProvider
    {
        public static IEnumerable<Album> GetAlbums()
        {
            var nehakakkarAlbum = new Album
            {
                Title = "Neha Kakkar Album",
                Songs = new List<Song>
                    {
                        new Song
                        {
                            Name = "Dilbar Dilbar",
                            Brief = "<p>Chadha jo mujhpe suroor hai<br> Asar tera yeh zaroor hai<br> Teri nazar ka kasoor hai</p>",
                        },
                    new Song
                        {
                            Name = "COCA COLA",
                            Brief = "<p>Sanwali saloni<br> Adayein manmohni<br> Teri jaisi beauty<br> Kisi ki bhi nahi honi<br> Thande ki bottle<br> Main tera opener<br> Tujhe gat gat main peelun</p>",
                        },
                    },
            };

            var atifAslamAlbum = new Album
            {
                Title = "Atif's Back",
                Songs = new List<Song>
                    {
                        new Song
                        {
                            Name = "Tere Bin Yaara",
                            Brief = "<p>Tere bin yaara<br> Berang bahara<br> Hai raat deewani<br> Naa neend gawara.</p>",
                        },
                }
            };

            var albums = new List<Album>
            {
                nehakakkarAlbum,
                atifAslamAlbum,
            };

            return albums;
        }
    }
}
