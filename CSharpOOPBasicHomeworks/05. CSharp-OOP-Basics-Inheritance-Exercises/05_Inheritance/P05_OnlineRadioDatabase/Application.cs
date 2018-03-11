namespace P05_OnlineRadioDatabase
{
    using System;
    using System.Collections.Generic;

    public class Application
    {
        public static void Main()
        {
            Database database = new Database();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] info = Console.ReadLine().Split(';');
                    if (info.Length != 3)
                    {
                        throw new InvalidSongException();
                    }

                    database.AddSong(new Song(info[0], info[1], info[2]));
                    Console.WriteLine("Song added.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Songs added: {0}", database.TotalSongsCount);
            Console.WriteLine(
                "Playlist length: {0}h {1}m {2}s",
                database.TotalSongsLength.Hours,
                database.TotalSongsLength.Minutes,
                database.TotalSongsLength.Seconds);
        }
    }

    internal class Database
    {
        private List<Song> playList;

        internal Database()
        {
            this.playList = new List<Song>();
        }

        internal int TotalSongsCount
        {
            get
            {
                return this.playList.Count;
            }
        }

        internal TimeSpan TotalSongsLength
        {
            get
            {
                return this.CalculateTotalSongsLength();
            }
        }

        internal void AddSong(Song song)
        {
            this.playList.Add(song);
        }

        private TimeSpan CalculateTotalSongsLength()
        {
            TimeSpan ts = new TimeSpan(0, 0, 0);
            foreach (Song song in this.playList)
            {
                ts = ts.Add(song.SongLength);
            }

            return ts;
        }
    }

    internal class Song
    {
        private readonly TimeSpan songLength;
        private string artistName;
        private string songName;

        internal Song(string artistName, string songName, string duration)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.songLength = this.GetSongLength(duration);
        }

        internal TimeSpan SongLength
        {
            get
            {
                return this.songLength;
            }
        }

        private string ArtistName
        {
            get
            {
                return this.artistName;
            }

            set
            {
                if (value == null || value.Length < 3 || 20 < value.Length)
                {
                    throw new InvalidArtistNameException();
                }

                this.artistName = value;
            }
        }

        private string SongName
        {
            get
            {
                return this.songName;
            }

            set
            {
                if (value == null || value.Length < 3 || 30 < value.Length)
                {
                    throw new InvalidSongNameException();
                }

                this.songName = value;
            }
        }

        private TimeSpan GetSongLength(string duration)
        {
            string[] songLengthParameters = duration.Split(':');

            if (duration == null)
            {
                throw new InvalidSongLengthException();
            }

            int minutes;
            int seconds;
            try
            {
                minutes = int.Parse(songLengthParameters[0]);
                seconds = int.Parse(songLengthParameters[1]);
            }
            catch (FormatException)
            {
                throw new InvalidSongLengthException();
            }

            if (minutes < 0 || 14 < minutes)
            {
                throw new InvalidSongMinutesException();
            }

            if (seconds < 0 || 59 < seconds)
            {
                throw new InvalidSongSecondsException();
            }

            return new TimeSpan(0, minutes, seconds);
        }
    }

    internal class InvalidSongException : ArgumentException
    {
        private const string Defaultessage = "Invalid song.";

        public InvalidSongException()
            : base(Defaultessage)
        {
        }

        public InvalidSongException(string message)
            : base(message)
        {
        }
    }

    internal class InvalidArtistNameException : InvalidSongException
    {
        private const string Defaultessage = "Artist name should be between 3 and 20 symbols.";

        public InvalidArtistNameException()
            : base(Defaultessage)
        {
        }

        public InvalidArtistNameException(string message)
            : base(message)
        {
        }
    }

    internal class InvalidSongNameException : InvalidSongException
    {
        private const string Defaultessage = "Song name should be between 3 and 30 symbols.";

        public InvalidSongNameException()
            : base(Defaultessage)
        {
        }

        public InvalidSongNameException(string message)
            : base(message)
        {
        }
    }

    internal class InvalidSongLengthException : InvalidSongException
    {
        private const string Defaultessage = "Invalid song length.";

        public InvalidSongLengthException()
            : base(Defaultessage)
        {
        }

        public InvalidSongLengthException(string message)
            : base(message)
        {
        }
    }

    internal class InvalidSongMinutesException : InvalidSongLengthException
    {
        private const string Defaultessage = "Song minutes should be between 0 and 14.";

        public InvalidSongMinutesException()
            : base(Defaultessage)
        {
        }

        public InvalidSongMinutesException(string message)
            : base(message)
        {
        }
    }

    internal class InvalidSongSecondsException : InvalidSongLengthException
    {
        private const string Defaultessage = "Song seconds should be between 0 and 59.";

        public InvalidSongSecondsException()
            : base(Defaultessage)
        {
        }

        public InvalidSongSecondsException(string message)
            : base(message)
        {
        }
    }
}