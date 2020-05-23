using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GemmMusic.Model
{
    public enum MusicCategory
    {
        Brunos,
        Demis,
        Drakes,
        Selenas,
        MyPlaylist
    }
    public class Music
    {
        public string Name { get; set; }
        public MusicCategory Category { get; set; }
        public string ImageFile { get; set; }
        public string AudioFile { get; set; }
        public string Album { get; set; }

        public Music (string name, MusicCategory category)
        {
            Name = name;
            Category = category;
            AudioFile = $"Assets/Audio/{category}/{name}.mp3";
            ImageFile = $"Assets/Images/{category}/{name}.png";
            Album = "";
        }

        public Music(string name, MusicCategory category, string audioFile , string album)
        {
            Name = name;
            Category = category;
            AudioFile = audioFile;
            ImageFile = $"Assets/Images/MyPlaylist.png";
            Album = "";
        }
    }
}
