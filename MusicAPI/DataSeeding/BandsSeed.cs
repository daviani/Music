using MusicApi.Entities;

namespace MusicApi.DataSeeding
{
    using Microsoft.EntityFrameworkCore;

    public static class BandsSeed
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>().HasData(
                new Band { Id = 1, Name = "Vaino", Status = "Active", FormedIn = 0, Genre = "Black Metal", CountryId = 1 },
                new Band { Id = 2, Name = "Bedrag", Status = "Active", FormedIn = 0, Genre = "Black Metal", CountryId = 2 },
                new Band { Id = 3, Name = "Leftmuenang", Status = "Changed name", FormedIn = 2013, Genre = "Black Metal with folk influences", CountryId = 4 },
                new Band { Id = 4, Name = "Armageddon", Status = "Active", FormedIn = 2003, Genre = "Black/Thrash Metal", CountryId = 4 }
            );      
            modelBuilder.Entity<BandMember>().HasData(
                new BandMember { BandId = 1, MemberId = 1 },
                new BandMember { BandId = 1, MemberId = 2 },
                new BandMember { BandId = 2, MemberId = 3 },
                new BandMember { BandId = 2, MemberId = 4 }
            );
        }
    }
}