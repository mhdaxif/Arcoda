using Data.MusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.MusicStore.Data
{
    public static class MockDataProvider
    {
        public static IEnumerable<Album> GetAlbums()
        {
            var genre = new Genre
            {
                Name = "Classic",
                Description = "Classic collection"
            };

            var nehaKakkar = new Artist
            {
                Name = "Neha Kakkar",
            };

            var atifAslam = new Artist
            {
                Name = "Atif Aslam",
            };

            var nehakakkarAlbum = new Album
            {
                Brief = "Neha Kakkar",
                Title = "Neha Kakkar Album",
                Artist = nehaKakkar,
                Genre = genre,
                Songs = new List<Song>
                    {
                        new Song
                        {
                            Name = "Dilbar Dilbar",
                            Brief = "<p>Chadha jo mujhpe suroor hai<br> Asar tera yeh zaroor hai<br> Teri nazar ka kasoor hai</p>",
                            SongContent = "<div class='entry-content' itemprop='text'><h2>Dilbar Dilbar Lyrics</h2><p>Dilbar dilbar…</p><div   style='float: right; margin - left: 10px;' id='whato -1007159668'></div><p>Chadha jo mujhpe suroor hai<br> Asar tera yeh zaroor hai<br> Teri nazar ka kasoor hai</p><p>Dilbar dilbar…</p><p>Aa paas aa tu kyun door hai<br> Yeh ishq ka jo fitoor hai<br> Nashe mein dil tere choor hai</p><p>Dilbar dilbar…</p><p>Ab toh hosh na khabar hai<br> Yeh kaisa asar hai<br> Hosh na khabar hai<br> Yeh kaisa asar hai<br> Tumse milne ke baad dilbar<br> Tumse milne ke baad dilbar</p><div class='whato-after-7-paragraph' id='whato-509152787'><script async='' src='http://www.whatobuy.in/wp-content/cache/abtf/proxy/98/31/1e/98311e1088e466ab7425e6580ae2c43e.js'></script> <ins class='adsbygoogle' style='display:block; text-align:center;' data-ad-client='ca-pub-1148978265026406' data-ad-slot='2265082174' data-ad-layout='in-article' data-ad-format='fluid' data-adsbygoogle-status='done'></ins> <script>(adsbygoogle = window.adsbygoogle || []).push({});</script> </div><p>Dilbar dilbar… dilbar dilbar…<br> Dilbar dilbar… dilbar dilbar…</p><p>[Ikka Rap]<br> Karti qatal na aise tu chal<br> Paheli ka iss nikalo koi hal<br> Husan ka pitara khilta kamal<br> Kar loonga sabar kyunki meetha hai phal</p><p>Tu mera khaab hai<br> Tu mere dil ka qaraar<br> Dekh le jaan-e-mann<br> Dekh le bas ek baar…</p><p>Chain kho gaya hai<br> Kuch toh ho gaya hai<br> Chain kho gaya hai<br> Kuch toh ho gaya hai<br> Tumse milne ke baad dilbar<br> Tumse milne ke baad dilbar</p><p>Oh yeah!</p><p>Ladies…<br> Ab toh hosh na khabar hai<br> Yeh kaisa asar hai<br> Hosh na khabar hai<br> Yeh kaisa asar hai<br> Tumse milne ke baad dilbar<br> Tumse milne ke baad dilbar</p><p>Ho!</p></div>",
                            Description = "description",
                            Artist = nehaKakkar,
                        },
                    new Song
                        {
                            Name = "COCA COLA",
                            Brief = "<p>Sanwali saloni<br> Adayein manmohni<br> Teri jaisi beauty<br> Kisi ki bhi nahi honi<br> Thande ki bottle<br> Main tera opener<br> Tujhe gat gat main peelun</p>",
                            SongContent = "<p>Sanwali saloni<br> Adayein manmohni<br> Teri jaisi beauty<br> Kisi ki bhi nahi honi<br> Thande ki bottle<br> Main tera opener<br> Tujhe gat gat main peelun</p> <p>Coca Cola tu…<br> Shola shola tu…<br> Gym-shym karta hoon<br> Ted mera lead aa<br> Ni tu boldi ae gallan<br> Jivein chaldi machine aa<br> Ni tu 24vi ghante vekhdi ain<br> Scooby-Dooby-Doo<br> Halle rehn de naa boli<br> I Love You!<br> Pehle khol le tu botal<br> Galiyon peh jave raula yun<br> Ki saare bole tujhe Coca Cola tu</p> <p>Na samajh tu coca cola<br> Main taa whiskey di botal<br> Mera ik sip hi hai kaafi<br> Hone ko no shot</p> <p>Chakhna manaa hai<br> Rukna manaa hai<br> Mujhe peele zara aa tu<br> Coca Cola tu…<br> Shola shola tu…</p> <p>Coca Cola tu…<br> Shola shola tu…</p> ",
                            Description = "description",
                            Artist = nehaKakkar,
                        },
                    },
            };

            var atifAslamAlbum = new Album
            {
                Brief = "Atif Aslam album",
                Title = "Atif's Back",
                Artist = atifAslam,
                Genre = genre,
                Songs = new List<Song>
                    {
                        new Song
                        {
                            Name = "Tere Bin Yaara",
                            Brief = "<p>Tere bin yaara<br> Berang bahara<br> Hai raat deewani<br> Naa neend gawara.</p>",
                            SongContent = "<h2>Tere Bin Yaara Lyrics</h2> <p>Tere bin yaara<br> Berang bahara<br> Hai raat deewani<br> Naa neend gawara.</p> <p>O karam khudaya hai<br> Tujhe dil mein basaya hai<br> Khud toot ke dil mujhko<br> Iss mod pe laaya hai.</p> <p>O tere bin yaara<br> Berang bahara<br> Hai raat begaani<br> Hai rashq sahara</p> <p>O tere bin yaara<br> Berang bahara<br> Hai raat begaani<br> Na neend gawara</p> <p>Maine chhode hain baaki saare raaste<br> Bas aaya hoon, tere waaste<br> Meri saanson pe tera naam hai,<br> Pehchaan ve</p> <p>Maine chhode hain baaki saare raaste<br> Bas aaya hoon, tere waaste<br> Meri saanson pe tera naam hai,<br> Pehchaan ve</p>  <p>Maine kiye hazaaron minnatein<br> Mujhe mili na Rab ki rehmatein<br> Ik tu hi mera anjaam hai<br> Yeh maan ve</p>  <p>O karam khudaya hai<br> Tujhe dil mein basaya hai<br> Khud toot ke dil mujhko<br> Iss mod pe laaya hai</p>  <p>O tere bin yaara<br> Berang bahaara<br> Hai raat begaani<br> Hai rashq sahara</p>",
                            Description = "description",
                            Artist = atifAslam,
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
