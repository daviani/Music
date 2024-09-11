using MusicApi.Entities;

namespace MusicApi.DataSeeding
{
    using Microsoft.EntityFrameworkCore;

    public static class MembersSeed
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, Name = "Valtteri Pasanen", CountryId = 1, Gender = true, Instrument = "Guitar" },
                new Member { Id = 2, Name = "Nefandous", CountryId = 1, Gender = true, Instrument = "Guitar" },
                new Member { Id = 3, Name = "Sand", CountryId = 4, Gender = true, Instrument = "Vocals, Guitars, Bass (2013-2015), Vocals, All instruments (2015-?)" },
                new Member { Id = 4, Name = "Armageddon", CountryId = 3, Gender = true, Instrument = "Vocals, Guitars, Bass, Drums, Programming" }
            );
        }
    }
}