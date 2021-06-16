using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    public enum SongArtist
    {
        Taylor,
        Selena,
        Beyonce,
        Sia
    }

    public class Song
    {
        public string SongTitle { get; set; }
        public SongArtist Artist { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }

        public Song(string songTitle, SongArtist artist) 
        {
            SongTitle = songTitle;
            Artist = artist;
            AudioFile = $"/Assets/Audio/{artist}/{songTitle}.mp3";
            ImageFile = $"/Assets/SongPics/Music.png";
        }
    }    
}
