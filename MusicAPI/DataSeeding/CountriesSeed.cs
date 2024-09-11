using MusicApi.Entities;

namespace MusicApi.DataSeeding
{
    using Microsoft.EntityFrameworkCore;

    public static class CountriesSeed
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countrie>().HasData(
                new Countrie { Id = 1, Name = "Finland" },
                new Countrie { Id = 2, Name = "Norway" },
                new Countrie { Id = 3, Name = "France" },
                new Countrie { Id = 4, Name = "Thailand" }
            );
        }
    }
}