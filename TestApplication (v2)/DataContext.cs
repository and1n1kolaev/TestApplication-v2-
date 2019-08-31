using Microsoft.EntityFrameworkCore;
using TestApplication__v2_.Models;

namespace TestApplication__v2_
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Initial Catalog=MusicDB;Integrated Security=True;");
        }

        public DbSet<PerformerModel> Performers { get; set; }
        public DbSet<AlbumModel> Albums { get; set; }
        public DbSet<TrackModel> Tracks { get; set; }
    }
}