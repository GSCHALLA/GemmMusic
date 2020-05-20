
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System;
using GemmMusic.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Drawing;
using Windows.UI.Xaml.Media.Imaging;
using System.Linq;
using Windows.Media.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GemmMusic
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Music> songs;
        private List<MenuItem> MenuItems;

        //private Music currentSong;

        //private bool playerView;
        
        public MainPage()
        {
            this.InitializeComponent();
            songs = new ObservableCollection<Music>();
            MusicManager.GetAllSongs(songs);

            MenuItems = new List<MenuItem>();
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/bruno.png", Category = MusicCategory.Brunos });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/demi.png", Category = MusicCategory.Demis });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/drake.png", Category = MusicCategory.Drakes });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/selena.png", Category = MusicCategory.Selenas });

            BackButton.Visibility = Visibility.Collapsed;
        }

        private void MenuItemList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            CategoryTextBlock.Text = menuItem.Category.ToString();
            MusicManager.GetSongsByCategory(songs, menuItem.Category);
            BackButton.Visibility = Visibility.Visible;
            SoundGridView.Visibility = Visibility.Visible;
            mySearchBox.Visibility = Visibility.Visible;

            MusicTitle.Visibility = Visibility.Visible;



        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var song = (Music)e.ClickedItem;
            MyMediaElement.Source = MediaSource.CreateFromUri(new Uri(BaseUri, song.AudioFile));
            SelectedImage.ImageSource = new BitmapImage(new Uri(BaseUri, song.ImageFile));
           
            SoundGridView.Visibility = Visibility.Collapsed;
            mySearchBox.Visibility = Visibility.Collapsed;
            CategoryTextBlock.Visibility = Visibility.Collapsed;
            MyMediaElement.Visibility = Visibility.Visible;

            MusicTitle.Visibility = Visibility.Visible;
            var file = TagLib.File.Create(song.AudioFile);
            MusicTitle.Text = file.Tag.Title;
        }

        private void HamBurgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MusicManager.GetAllSongs(songs);
            CategoryTextBlock.Text = "All Songs";
            MenuItemList.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void mySearchBox_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
           
            MusicManager.SearchByName(songs, args.QueryText);
        }

        private void PlayerView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}


//
//            //TagLib.IPicture pic = file.Tag.Pictures[0];
//            //MemoryStream stream = new MemoryStream(pic.Data.Data);

//            //System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

//            //image.GetThumbnailImage