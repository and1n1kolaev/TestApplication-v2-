using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication__v2_.Models
{
    public class PerformerModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public int CareerStartYear { get; set; }
        public virtual List<AlbumModel> Album { get; set; }

        public PerformerModel() { }

        public PerformerModel(string name, int age, string genre, int careerStart)
        {
            Name = name;
            Age = age;
            Genre = genre;
            CareerStartYear = careerStart;

        }
    }
}
