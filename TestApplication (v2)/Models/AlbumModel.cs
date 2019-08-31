using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication__v2_.Models
{
    public class AlbumModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int ReleaseYear { get; private set; }
        public List<TrackModel> Tracks { get; private set; }

        public AlbumModel() { }

        public AlbumModel(string name, int release, List<TrackModel> tracks)
        {
            Name = name;
            ReleaseYear = release;
            Tracks = tracks;
        }
    }
}
