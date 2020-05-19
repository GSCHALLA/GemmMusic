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

        public static void GetSongsByCategory(ObservableCollection<Music> songs, MusicCategory category)
        {
            var allsongs = getSongs();
            var filteredSounds = allsongs.Where(song => song.Category == category).ToList();
            songs.Clear();
            filteredSounds.ForEach(song => songs.Add(song));
        }

        private static List<Music> getSongs()
        {
            var songs = new List<Music>();
            songs.Add(new Music("ShapeOfYou", MusicCategory.Brunos));
            songs.Add(new Music("Cheap Thrills", MusicCategory.Demis));
            songs.Add(new Music("ShapeOfYou", MusicCategory.Brunos));
            songs.Add(new Music("Cheap Thrills", MusicCategory.Demis));
            songs.Add(new Music("ShapeOfYou", MusicCategory.Brunos));
            songs.Add(new Music("Cheap Thrills", MusicCategory.Demis));
            songs.Add(new Music("ShapeOfYou", MusicCategory.Brunos));
            songs.Add(new Music("Cheap Thrills", MusicCategory.Demis));
            songs.Add(new Music("ShapeOfYou", MusicCategory.Brunos));
            songs.Add(new Music("Cheap Thrills", MusicCategory.Demis));

            return songs;

        }

        /* Search button - Searching based on name and category - starts here */

        public static void SearchByName(ObservableCollection<Music> songs, string queryText)
        {
            var allsongs = getSongs();
            var SearchedSongsByNameCategory = 
                allsongs.Where(song => song.Name.ToUpper().Contains(queryText.ToUpper())
                || song.Category.ToString().ToUpper().Contains(queryText.ToUpper())).ToList();
            songs.Clear();
            SearchedSongsByNameCategory.ForEach(song => songs.Add(song));

          /* Search button - Searching based on name and category - ends here */

        }
    }
}
