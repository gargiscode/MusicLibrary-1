using MusicLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibrary
{
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Song> Songs;
        private List<MenuItem> MenuItems;
        public MainPage()
        {
            this.InitializeComponent();
            Songs = new ObservableCollection<Song>();
            SongManager.GetAllSongs(Songs);

            MenuItems = new List<MenuItem>
            { new MenuItem
            {
                Artist = SongArtist.Beyonce,
                ArtistImage = "/Assets/ArtistImage/Beyonce.png"
            },
                new MenuItem
                {
                    Artist = SongArtist.Selena,
                    ArtistImage = "/Assets/ArtistImage/Selena.png"
                },
                new MenuItem
                {
                    Artist = SongArtist.Sia,
                    ArtistImage = "/Assets/ArtistImage/Sia.png"
                },
                new MenuItem
                {
                    Artist = SongArtist.Taylor,
                    ArtistImage = "/Assets/ArtistImage/Taylor.png"
                }
            };
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !(MySplitView.IsPaneOpen);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SongManager.GetAllSongs(Songs);
            ArtistTextBlock.Text = "Music Library";
            BackButton.Visibility = Visibility.Collapsed;

        }

        private void MenuItemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            ArtistTextBlock.Text = menuItem.Artist.ToString();
            SongManager.GetSongsByArtist(Songs, menuItem.Artist);

            BackButton.Visibility = Visibility.Visible;

        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

            var song = (Song)e.ClickedItem;
            MyMediaElement.Source = new Uri(this.BaseUri, song.AudioFile);

        }
    }
}

