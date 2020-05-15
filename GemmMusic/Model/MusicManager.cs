using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemmMusic.Model
{
    public static class MusicManager
    {
        public static void GetAllSongs(ObservableCollection<Music> songs)
        {
            var allSongs = getSongs();
            songs.Clear();

            getSongs().ForEach(song => songs.Add(song));

        }

        private static List<Music> getSongs()
        {
            var songs = new List<Music>();
            songs.Add(new Music("ShapeOfYou", MusicCategory.Brunos));

            return songs;

        }
    }
}
