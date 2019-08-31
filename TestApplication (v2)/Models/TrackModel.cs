using System;

namespace TestApplication__v2_.Models
{
    public class TrackModel
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public TimeSpan Duration { get;  set; }
        public bool IsFavorite { get;  set; }
        public bool IsListened { get;  set; }
        public int Rating { get; set; }

    }
}