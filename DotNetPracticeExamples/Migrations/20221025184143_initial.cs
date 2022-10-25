﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetPracticeExamples.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverArtUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    ForSale = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
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
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "CoverArtUrl", "ForSale", "Genre", "Rating", "StatusId", "Title" },
                values: new object[,]
                {
                    { 1, "https://www.website.com/coverart.jpg", true, "Psytrance", 11, 1, "Psytrance Album" },
                    { 2, "https://www.popwebsite.com/coverart.jpg", false, "Pop", 22, 2, "Popular Album" },
                    { 3, "https://www.mixalbum.com/coverart.jpg", true, "Various", 33, 3, "Mix Album" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "AlbumId", "Artist", "Duration", "ForSale", "Genre", "Rating", "StatusId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Psyonysus", new TimeSpan(0, 0, 8, 25, 0), true, "Psytrance", 11, 1, "Exit Samsara" },
                    { 2, 1, "Psyonysus", new TimeSpan(0, 0, 8, 36, 0), false, "Psytrance", 22, 2, "Tryptonite" },
                    { 3, 1, "LIFTSHIFT", new TimeSpan(0, 0, 9, 26, 0), true, "Psytrance", 33, 3, "Plant Life" },
                    { 4, null, "Stereofeld", new TimeSpan(0, 0, 6, 55, 0), false, "Psytrance", 44, 1, "No Fear" },
                    { 5, 2, "Justice", new TimeSpan(0, 0, 3, 12, 0), true, "Pop electronic", 55, 2, "Genesis" },
                    { 6, 2, "Sir Sly", new TimeSpan(0, 0, 3, 49, 0), false, "Pop", 66, 3, "High" },
                    { 7, 2, "Jungle", new TimeSpan(0, 0, 2, 28, 0), true, "Pop Disco", 77, 1, "Busy Earnin'" },
                    { 8, 3, "Bignic", new TimeSpan(0, 0, 5, 26, 0), false, "Television OST", 88, 2, "Gladius" },
                    { 9, null, "In Quantum", new TimeSpan(0, 0, 4, 6, 0), true, "Ambient", 99, 3, "Odyssey" },
                    { 10, 2, "Fatboy Slim", new TimeSpan(0, 0, 3, 46, 0), true, "Pop Electronic", 11, 1, "Bird of Prey" },
                    { 11, 3, "Ivan Torrent", new TimeSpan(0, 0, 4, 54, 0), true, "Classic Electronic", 22, 2, "Architects of Life (Feat. Celica Soldream)" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "SongsWithImage");
        }
    }
}
