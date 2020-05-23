using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemmMusic.Model
{
    public static class MusicManager
    {
        private static string MY_SONGS_PATH = "C:/Users/saige/source/repos/GemmMusic/GemmMusic/bin/x86/Debug/AppX/MyPlaylist";
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
            //songs.Add(new Music("ShapeOfYou", MusicCategory.Brunos));
            songs.Add(new Music("Magic", MusicCategory.Brunos));
            songs.Add(new Music("Uptown", MusicCategory.Brunos));
            //songs.Add(new Music("Cheap Thrills", MusicCategory.Demis));
            songs.Add(new Music("Confident", MusicCategory.Demis));
            songs.Add(new Music("Sorry", MusicCategory.Demis));
            songs.Add(new Music("Hotline", MusicCategory.Drakes));
            songs.Add(new Music("Scorpion", MusicCategory.Drakes));
             songs.Add (new Music("LoseU", MusicCategory.Selenas));
            
            songs.Add(new Music("StarsDance", MusicCategory.Selenas));

            

            var mySongs = getMySongs();
            songs.AddRange(mySongs);

            return songs;
           

        }

        private static List<Music> getMySongs()
        {
            var mySongs = new List<Music>();
            string[] fileEntries = Directory.GetFiles(MY_SONGS_PATH);
            foreach (string audioFilePath in fileEntries)
            {
                var file = TagLib.File.Create(audioFilePath);
             Music music =  new Music(file.Tag.Title, MusicCategory.MyPlaylist, audioFilePath, file.Tag.Album);

                if (music.Name == null)
                {
                    music.Name = " ";
                }
                mySongs.Add(music);
            }
            return mySongs;
        }

        /* Search button - Searching based on name and category - starts here */

        public static void SearchByName(ObservableCollection<Music> songs, string queryText)
        {
            var allsongs = getSongs();
            var SearchedSongsByNameCategory = 
                allsongs.Where(song => song.Name.ToUpper().Contains(queryText.ToUpper()) 
                ||song.Album != null && song.Album.ToString().ToUpper().Contains(queryText.ToUpper())
                || song.Category.ToString().ToUpper().Contains(queryText.ToUpper())).ToList();
            songs.Clear();
            SearchedSongsByNameCategory.ForEach(song => songs.Add(song));

          /* Search button - Searching based on name and category - ends here */

        }
    }
}
