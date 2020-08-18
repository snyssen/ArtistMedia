using ArtistMedia.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtistMedia
{
    public  class ArtistMediaContext : DbContext
    {
        public DbSet<Artist_Type> Artist_Types { get; set; }
        public DbSet<Area> Areas { get; set; }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-5A54U6A;Database=ArtistDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}