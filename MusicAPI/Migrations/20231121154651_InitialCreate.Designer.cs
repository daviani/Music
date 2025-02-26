﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicApi;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MusicApi.Migrations
{
    [DbContext(typeof(MusicDbContext))]
    [Migration("20231121154651_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MusicApi.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BandId")
                        .HasColumnType("integer");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BandId = 1,
                            Titre = "Metsänpeitto"
                        },
                        new
                        {
                            Id = 2,
                            BandId = 2,
                            Titre = "Diabolical Goat Cancer"
                        },
                        new
                        {
                            Id = 3,
                            BandId = 2,
                            Titre = "Bedrag"
                        },
                        new
                        {
                            Id = 4,
                            BandId = 3,
                            Titre = "Illusion"
                        },
                        new
                        {
                            Id = 5,
                            BandId = 4,
                            Titre = "Necromantic Celebration"
                        },
                        new
                        {
                            Id = 6,
                            BandId = 4,
                            Titre = "Through the Endless Torments of Hell"
                        });
                });

            modelBuilder.Entity("MusicApi.Entities.Band", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountriesId")
                        .HasColumnType("integer");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<int>("FormedIn")
                        .HasColumnType("integer");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountriesId");

                    b.ToTable("Bands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            FormedIn = 0,
                            Genre = "Black Metal",
                            Name = "Vaino",
                            Status = "Active"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            FormedIn = 0,
                            Genre = "Black Metal",
                            Name = "Bedrag",
                            Status = "Active"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 4,
                            FormedIn = 2013,
                            Genre = "Black Metal with folk influences",
                            Name = "Leftmuenang",
                            Status = "Changed name"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 4,
                            FormedIn = 2003,
                            Genre = "Black/Thrash Metal",
                            Name = "Armageddon",
                            Status = "Active"
                        });
                });

            modelBuilder.Entity("MusicApi.Entities.BandMember", b =>
                {
                    b.Property<int>("BandId")
                        .HasColumnType("integer");

                    b.Property<int>("MemberId")
                        .HasColumnType("integer");

                    b.HasKey("BandId", "MemberId");

                    b.HasIndex("MemberId");

                    b.ToTable("BandMembers");

                    b.HasData(
                        new
                        {
                            BandId = 1,
                            MemberId = 1
                        },
                        new
                        {
                            BandId = 1,
                            MemberId = 2
                        },
                        new
                        {
                            BandId = 2,
                            MemberId = 3
                        });
                });

            modelBuilder.Entity("MusicApi.Entities.Countrie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Finland"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Norway"
                        },
                        new
                        {
                            Id = 3,
                            Name = "France"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Thailand"
                        });
                });

            modelBuilder.Entity("MusicApi.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<bool>("Gender")
                        .HasColumnType("boolean");

                    b.Property<string>("Instrument")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Gender = true,
                            Instrument = "Guitar",
                            Name = "Valtteri Pasanen"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Gender = true,
                            Instrument = "Guitar",
                            Name = "Nefandous"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 4,
                            Gender = true,
                            Instrument = "Vocals, Guitars, Bass (2013-2015), Vocals, All instruments (2015-?)",
                            Name = "Sand"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 3,
                            Gender = true,
                            Instrument = "Vocals, Guitars, Bass, Drums, Programming",
                            Name = "Armageddon"
                        });
                });

            modelBuilder.Entity("MusicApi.Entities.Album", b =>
                {
                    b.HasOne("MusicApi.Entities.Band", "Bands")
                        .WithMany()
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bands");
                });

            modelBuilder.Entity("MusicApi.Entities.Band", b =>
                {
                    b.HasOne("MusicApi.Entities.Countrie", "Countries")
                        .WithMany()
                        .HasForeignKey("CountriesId");

                    b.Navigation("Countries");
                });

            modelBuilder.Entity("MusicApi.Entities.BandMember", b =>
                {
                    b.HasOne("MusicApi.Entities.Band", "Band")
                        .WithMany("BandMembers")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicApi.Entities.Member", "Member")
                        .WithMany("BandMembers")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Band");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("MusicApi.Entities.Band", b =>
                {
                    b.Navigation("BandMembers");
                });

            modelBuilder.Entity("MusicApi.Entities.Member", b =>
                {
                    b.Navigation("BandMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
