using Microsoft.EntityFrameworkCore;
using MusicApi.DataSeeding;
using MusicApi.Entities;


namespace MusicApi;

public class MusicDbContext : DbContext
{
    public DbSet<Band> Bands { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Countrie> Countries { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<BandMember> BandMembers { get; set; }

    public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options) {  }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BandMember>()
            .HasKey(bm => new { bm.BandId, bm.MemberId });

        modelBuilder.Entity<BandMember>()
            .HasOne(bm => bm.Band)
            .WithMany(bm => bm.BandMembers)
            .HasForeignKey(bm => bm.BandId );

        modelBuilder.Entity<BandMember>()
            .HasOne(bm => bm.Member)
            .WithMany(bm => bm.BandMembers)
            .HasForeignKey(bm => bm.MemberId);
        
        BandsSeed.SeedData(modelBuilder);
        AlbumsSeed.SeedData(modelBuilder);
        CountriesSeed.SeedData(modelBuilder);
        MembersSeed.SeedData(modelBuilder);
    }
}