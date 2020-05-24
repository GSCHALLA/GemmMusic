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
        //This comes from appx folder.

        private static string MY_SONGS_PATH = "MyPlaylist";
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
            //songs.Add(new Music("Magic", MusicCategory.Brunos));
            //songs.Add(new Music("Uptown", MusicCategory.Brunos));
            ////songs.Add(new Music("Cheap Thrills", MusicCategory.Demis));
            //songs.Add(new Music("Confident", MusicCategory.Demis));
            //songs.Add(new Music("Sorry", MusicCategory.Demis));
            //songs.Add(new Music("Hotline", MusicCategory.Drakes));
            //songs.Add(new Music("Scorpion", MusicCategory.Drakes));
            //songs.Add (new Music("LoseU", MusicCategory.Selenas));
            
            //songs.Add(new Music("StarsDance", MusicCategory.Selenas));

            songs.Add(new Music("Magic", MusicCategory.Brunos, "24K Magic", "Bruno Mars"));
            songs.Add(new Music("Uptown", MusicCategory.Brunos, "UpTownFunk", "Mark Ronson"));
            songs.Add(new Music("Confident", MusicCategory.Demis, "ConfidentR", "Demi Lovato"));
            songs.Add(new Music("Sorry", MusicCategory.Demis, "Souveniers", "Demis Rousso"));
            songs.Add(new Music("Hotline", MusicCategory.Drakes, "Hotline Bling", "Drake Graham"));
            songs.Add(new Music("Scorpion", MusicCategory.Drakes, "Scorpion 2018", "Drake Graham"));
            songs.Add(new Music("LoseU", MusicCategory.Selenas, "Lose You to Love Me", "Selena Gomez"));
            songs.Add(new Music("StarsDance", MusicCategory.Selenas, "Stars Dance 2013", "Selena Gomez"));




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
                string artistname = string.Empty;
                if (file.Tag.Artists != null && file.Tag.Artists.Length > 0)
                    artistname = file.Tag.Artists[0];
                Music music =  new Music(file.Tag.Title, MusicCategory.MyPlaylist, audioFilePath, file.Tag.Album, artistname);

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
                ||song.Artist != null && song.Artist.ToString().ToUpper().Contains(queryText.ToUpper())
                || song.Category.ToString().ToUpper().Contains(queryText.ToUpper())).ToList();
            songs.Clear();
            SearchedSongsByNameCategory.ForEach(song => songs.Add(song));

          /* Search button - Searching based on name and category - ends here */

        }
    }
}
