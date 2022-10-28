﻿// <auto-generated />
using System;
using DotNetPracticeExamples.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetPracticeExamples.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20221028181051_changingFromGenreNameToGenreId")]
    partial class changingFromGenreNameToGenreId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetPracticeExamples.Models.Album", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverArtUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ForSale")
                        .HasColumnType("bit");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoverArtUrl = "https://www.website.com/coverart.jpg",
                            ForSale = true,
                            Genre = "Psytrance",
                            GenreId = 1,
                            Rating = 11,
                            StatusId = 1,
                            Title = "Psytrance Album"
                        },
                        new
                        {
                            Id = 2,
                            CoverArtUrl = "https://www.popwebsite.com/coverart.jpg",
                            ForSale = false,
                            Genre = "Pop",
                            GenreId = 4,
                            Rating = 22,
                            StatusId = 2,
                            Title = "Popular Album"
                        },
                        new
                        {
                            Id = 3,
                            CoverArtUrl = "https://www.mixalbum.com/coverart.jpg",
                            ForSale = true,
                            Genre = "Various",
                            GenreId = 11,
                            Rating = 33,
                            StatusId = 3,
                            Title = "Mix Album"
                        });
                });

            modelBuilder.Entity("DotNetPracticeExamples.Models.Genre", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreType = "Psytrance"
                        },
                        new
                        {
                            Id = 2,
                            GenreType = "Electronic"
                        },
                        new
                        {
                            Id = 3,
                            GenreType = "Pop Electronic"
                        },
                        new
                        {
                            Id = 4,
                            GenreType = "Pop"
                        },
                        new
                        {
                            Id = 5,
                            GenreType = "Disco"
                        },
                        new
                        {
                            Id = 6,
                            GenreType = "Pop Disco"
                        },
                        new
                        {
                            Id = 7,
                            GenreType = "Pop Disco"
                        },
                        new
                        {
                            Id = 8,
                            GenreType = "Television OST"
                        },
                        new
                        {
                            Id = 9,
                            GenreType = "Ambient"
                        },
                        new
                        {
                            Id = 10,
                            GenreType = "Classic Electronic"
                        },
                        new
                        {
                            Id = 11,
                            GenreType = "Various"
                        });
                });

            modelBuilder.Entity("DotNetPracticeExamples.Models.Song", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<bool?>("ForSale")
                        .HasColumnType("bit");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlbumId = 1,
                            Artist = "Psyonysus",
                            Duration = new TimeSpan(0, 0, 8, 25, 0),
                            ForSale = true,
                            Genre = "Psytrance",
                            GenreId = 1,
                            Rating = 11,
                            StatusId = 1,
                            Title = "Exit Samsara"
                        },
                        new
                        {
                            Id = 2,
                            AlbumId = 1,
                            Artist = "Psyonysus",
                            Duration = new TimeSpan(0, 0, 8, 36, 0),
                            ForSale = false,
                            Genre = "Psytrance",
                            GenreId = 1,
                            Rating = 22,
                            StatusId = 2,
                            Title = "Tryptonite"
                        },
                        new
                        {
                            Id = 3,
                            AlbumId = 1,
                            Artist = "LIFTSHIFT",
                            Duration = new TimeSpan(0, 0, 9, 26, 0),
                            ForSale = true,
                            Genre = "Psytrance",
                            GenreId = 1,
                            Rating = 33,
                            StatusId = 3,
                            Title = "Plant Life"
                        },
                        new
                        {
                            Id = 4,
                            Artist = "Stereofeld",
                            Duration = new TimeSpan(0, 0, 6, 55, 0),
                            ForSale = false,
                            Genre = "Psytrance",
                            GenreId = 1,
                            Rating = 44,
                            StatusId = 1,
                            Title = "No Fear"
                        },
                        new
                        {
                            Id = 5,
                            AlbumId = 2,
                            Artist = "Justice",
                            Duration = new TimeSpan(0, 0, 3, 12, 0),
                            ForSale = true,
                            Genre = "Pop electronic",
                            GenreId = 3,
                            Rating = 55,
                            StatusId = 2,
                            Title = "Genesis"
                        },
                        new
                        {
                            Id = 6,
                            AlbumId = 2,
                            Artist = "Sir Sly",
                            Duration = new TimeSpan(0, 0, 3, 49, 0),
                            ForSale = false,
                            Genre = "Pop",
                            GenreId = 2,
                            Rating = 66,
                            StatusId = 3,
                            Title = "High"
                        },
                        new
                        {
                            Id = 7,
                            AlbumId = 2,
                            Artist = "Jungle",
                            Duration = new TimeSpan(0, 0, 2, 28, 0),
                            ForSale = true,
                            Genre = "Pop Disco",
                            GenreId = 5,
                            Rating = 77,
                            StatusId = 1,
                            Title = "Busy Earnin'"
                        },
                        new
                        {
                            Id = 8,
                            AlbumId = 3,
                            Artist = "Bignic",
                            Duration = new TimeSpan(0, 0, 5, 26, 0),
                            ForSale = false,
                            Genre = "Television OST",
                            GenreId = 8,
                            Rating = 88,
                            StatusId = 2,
                            Title = "Gladius"
                        },
                        new
                        {
                            Id = 9,
                            Artist = "In Quantum",
                            Duration = new TimeSpan(0, 0, 4, 6, 0),
                            ForSale = true,
                            Genre = "Ambient",
                            GenreId = 9,
                            Rating = 99,
                            StatusId = 3,
                            Title = "Odyssey"
                        },
                        new
                        {
                            Id = 10,
                            AlbumId = 2,
                            Artist = "Fatboy Slim",
                            Duration = new TimeSpan(0, 0, 3, 46, 0),
                            ForSale = true,
                            Genre = "Pop Electronic",
                            GenreId = 3,
                            Rating = 11,
                            StatusId = 1,
                            Title = "Bird of Prey"
                        },
                        new
                        {
                            Id = 11,
                            AlbumId = 3,
                            Artist = "Ivan Torrent",
                            Duration = new TimeSpan(0, 0, 4, 54, 0),
                            ForSale = true,
                            Genre = "Classic Electronic",
                            GenreId = 10,
                            Rating = 22,
                            StatusId = 2,
                            Title = "Architects of Life (Feat. Celica Soldream)"
                        });
                });

            modelBuilder.Entity("DotNetPracticeExamples.Models.SongWithImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SongsWithImage");
                });
#pragma warning restore 612, 618
        }
    }
}
