using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetPracticeExamples.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumDistributorComposite",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    DistributorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumDistributorComposite", x => new { x.AlbumId, x.DistributorId });
                });

            migrationBuilder.CreateTable(
                name: "AlbumFormatComposite",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    FormatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumFormatComposite", x => new { x.AlbumId, x.FormatId });
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    CoverArtUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    ForSale = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Distributors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SongDistributorComposite",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false),
                    DistributorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongDistributorComposite", x => new { x.SongId, x.DistributorId });
                });

            migrationBuilder.CreateTable(
                name: "SongFormatComposite",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false),
                    FormatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongFormatComposite", x => new { x.SongId, x.FormatId });
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    CopyrightId = table.Column<int>(type: "int", nullable: true),
                    ForSale = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SongsWithImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongsWithImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AlbumDistributorComposite",
                columns: new[] { "AlbumId", "DistributorId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "AlbumFormatComposite",
                columns: new[] { "AlbumId", "FormatId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 2, 2 },
                    { 1, 2 },
                    { 1, 1 },
                    { 2, 4 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 2 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "CoverArtUrl", "ForSale", "Genre", "GenreId", "StatusId", "Title" },
                values: new object[,]
                {
                    { 1, "https://www.website.com/coverart.jpg", true, "Psytrance", 1, 1, "Psytrance Album" },
                    { 3, "https://www.mixalbum.com/coverart.jpg", true, "Various", 10, 3, "Mix Album" },
                    { 2, "https://www.popwebsite.com/coverart.jpg", false, "Pop", 4, 2, "Popular Album" }
                });

            migrationBuilder.InsertData(
                table: "Distributors",
                columns: new[] { "Id", "Address", "City", "Name", "State", "Url", "ZipCode" },
                values: new object[,]
                {
                    { 3, null, null, "Super Downloads", null, "https://www.superdownloads.com", null },
                    { 4, "123 Sunset Blvd.", "Las Vegas", "Great Music Distro", "NV", "https://www.GMD.com", 89123 },
                    { 5, null, null, "Cheap Music Digital", null, "https://www.CheapSongs.com", null },
                    { 2, "PO Box 1234", "Another City", "DigiMusic", "VA", "https://www.digimusic.com", 23723 },
                    { 1, "123 Fake St", "Classic City", "Classic Records", "CA", null, 90210 }
                });

            migrationBuilder.InsertData(
                table: "Formats",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Digital Download" },
                    { 2, "Compact Disc" },
                    { 3, "Cassette Tape" },
                    { 4, "Record" },
                    { 5, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreType", "Rating" },
                values: new object[,]
                {
                    { 4, "Pop", 44 },
                    { 8, "Ambient", 88 },
                    { 7, "Television OST", 77 },
                    { 6, "Pop Disco", 66 },
                    { 5, "Disco", 55 },
                    { 11, "Other", 22 },
                    { 1, "Psytrance", 11 },
                    { 2, "Electronic", 22 },
                    { 9, "Classic Electronic", 99 },
                    { 3, "Pop Electronic", 33 },
                    { 10, "Various", 11 }
                });

            migrationBuilder.InsertData(
                table: "SongDistributorComposite",
                columns: new[] { "DistributorId", "SongId" },
                values: new object[,]
                {
                    { 5, 11 },
                    { 5, 10 },
                    { 4, 10 },
                    { 3, 2 },
                    { 4, 1 },
                    { 3, 1 },
                    { 2, 1 },
                    { 3, 10 },
                    { 2, 2 },
                    { 2, 10 },
                    { 3, 9 },
                    { 4, 2 },
                    { 5, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 4 },
                    { 5, 9 },
                    { 2, 5 },
                    { 4, 5 },
                    { 2, 6 },
                    { 3, 6 },
                    { 4, 6 },
                    { 1, 7 },
                    { 2, 7 },
                    { 3, 7 },
                    { 5, 7 },
                    { 2, 8 },
                    { 5, 8 },
                    { 5, 1 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "SongFormatComposite",
                columns: new[] { "FormatId", "SongId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 4 },
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "SongFormatComposite",
                columns: new[] { "FormatId", "SongId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 1, 11 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 },
                    { 1, 6 },
                    { 2, 6 },
                    { 1, 7 },
                    { 3, 7 },
                    { 4, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "AlbumId", "Artist", "CopyrightId", "Duration", "ForSale", "Genre", "GenreId", "Rating", "Title" },
                values: new object[,]
                {
                    { 4, null, "Stereofeld", 1, new TimeSpan(0, 0, 6, 55, 0), false, "Psytrance", 1, 44, "No Fear" },
                    { 6, 2, "Sir Sly", 3, new TimeSpan(0, 0, 3, 49, 0), false, "Pop", 4, 66, "High" },
                    { 7, 2, "Jungle", 1, new TimeSpan(0, 0, 2, 28, 0), true, "Pop Disco", 6, 77, "Busy Earnin'" },
                    { 8, 3, "Bignic", 2, new TimeSpan(0, 0, 5, 26, 0), false, "Television OST", 7, 88, "Gladius" },
                    { 5, 2, "Justice", 2, new TimeSpan(0, 0, 3, 12, 0), true, "Pop electronic", 3, 55, "Genesis" },
                    { 9, null, "In Quantum", 3, new TimeSpan(0, 0, 4, 6, 0), true, "Ambient", 8, 99, "Odyssey" },
                    { 3, 1, "LIFTSHIFT", 3, new TimeSpan(0, 0, 9, 26, 0), true, "Psytrance", 1, 33, "Plant Life" },
                    { 11, 3, "Ivan Torrent", 2, new TimeSpan(0, 0, 4, 54, 0), true, "Classic Electronic", 9, 22, "Architects of Life (Feat. Celica Soldream)" },
                    { 1, 1, "Psyonysus", 1, new TimeSpan(0, 0, 8, 25, 0), true, "Psytrance", 1, 11, "Exit Samsara" },
                    { 10, 2, "Fatboy Slim", 1, new TimeSpan(0, 0, 3, 46, 0), true, "Pop Electronic", 3, 11, "Bird of Prey" },
                    { 2, 1, "Psyonysus", 2, new TimeSpan(0, 0, 8, 36, 0), false, "Psytrance", 1, 22, "Tryptonite" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Description", "Type" },
                values: new object[,]
                {
                    { 5, "Public domain includes works that are public which means that they are not protected by copyright and can be used by anyone.", "Public Domain" },
                    { 4, "Orphaned works are those whose copyright owners are unknown or cannot be located. These works may be used freely under certain circumstances.", "Orphaned Works" },
                    { 3, "Derivative works are based on one or more preexisting works, such as a book, article, musical composition, or photograph.", "Derivative Works" },
                    { 2, "Fair Use allows for the use of copyrighted material without permission from the copyright holder for the purpose of criticism, commentary, news reporting, teaching, scholarship, or research.", "Fair Use" },
                    { 1, "A license is an agreement between a copyright holder and a user that allows the user to use the work in a way that would otherwise be infringing.", "Licensing" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumDistributorComposite");

            migrationBuilder.DropTable(
                name: "AlbumFormatComposite");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Distributors");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "SongDistributorComposite");

            migrationBuilder.DropTable(
                name: "SongFormatComposite");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "SongsWithImage");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
