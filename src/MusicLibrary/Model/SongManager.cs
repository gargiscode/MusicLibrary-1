using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    public static class SongManager
    {
        public static void GetAllSongs(ObservableCollection<Song> songs)
        {
            var allSongs = getSongs();
            songs.Clear();  //clear the observable collection
            allSongs.ForEach(song => songs.Add(song)); //add items to collection
        }

        public static void GetSongsByArtist(ObservableCollection<Song> songs, SongArtist artist)
        {
            var allSongs = getSongs();
            songs.Clear(); 
            var filteredSongs = allSongs.Where(song=> song.Artist == artist).ToList();
            filteredSongs.ForEach(song => songs.Add(song));
        }

        private static List<Song> getSongs()
        {
            var songs = new List<Song>();
            songs.Add(new Song("Beyonce1", SongArtist.Beyonce));
            songs.Add(new Song("Beyonce2", SongArtist.Beyonce));
            songs.Add(new Song("Selena1", SongArtist.Selena));
            songs.Add(new Song("Selena2", SongArtist.Selena));
            songs.Add(new Song("Sia1", SongArtist.Sia));
            songs.Add(new Song("Sia2", SongArtist.Sia));
            songs.Add(new Song("Taylor1", SongArtist.Taylor));
            songs.Add(new Song("Taylor2", SongArtist.Taylor));
            return songs;
        }
    }
}

