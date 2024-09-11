using Microsoft.EntityFrameworkCore;
using MusicApi.Entities;

public class AlbumsSeed
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>().HasData(
            new Album { Id = 1, Titre = "Metsänpeitto", BandId = 1 },
            new Album { Id = 2, Titre = "Diabolical Goat Cancer", BandId = 2 },
            new Album { Id = 3, Titre = "Bedrag", BandId = 2 },
            new Album { Id = 4, Titre = "Illusion", BandId = 3 },
            new Album { Id = 5, Titre = "Necromantic Celebration", BandId = 4 },
            new Album { Id = 6, Titre = "Through the Endless Torments of Hell", BandId = 4 }
        );
    }
}