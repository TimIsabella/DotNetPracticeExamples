using DotNetPracticeExamples.Models;
using System;
using System.Collections.Generic;

namespace DotNetPracticeExamples.Data
{
	public static class SongData
	{
		public static List<Song> Data = new List<Song>
		{
			new Song
			{
				Id = 1,
				Artist = "Psyonysus",
				Title = "Exit Samsara",
				Genre = "Psytrance",
				GenreId = 1,
				Duration = new TimeSpan(0, 8, 25),
				AlbumId = 1,
				Rating = 11,
				CopyrightId = 1,
				ForSale = true,
			},

			new Song
			{
				Id = 2,
				Artist = "Psyonysus",
				Title = "Tryptonite",
				Genre = "Psytrance",
				GenreId = 1,
				Duration = new TimeSpan(0, 8, 36),
				AlbumId = 1,
				Rating = 22,
				CopyrightId = 2,
				ForSale = false,
			},

			new Song
			{
				Id = 3,
				Artist = "LIFTSHIFT",
				Title = "Plant Life",
				Genre = "Psytrance",
				GenreId = 1,
				Duration = new TimeSpan(0, 9, 26),
				AlbumId = 1,
				Rating = 33,
				CopyrightId = 3,
				ForSale = true,
			},

			new Song
			{
				Id = 4,
				Artist = "Stereofeld",
				Title = "No Fear",
				Genre = "Psytrance",
				GenreId = 1,
				Duration = new TimeSpan(0, 6, 55),
				AlbumId = null,
				Rating = 44,
				CopyrightId = 1,
				ForSale = false,
			},

			new Song
			{
				Id = 5,
				Artist = "Justice",
				Title = "Genesis",
				Genre = "Pop electronic",
				GenreId = 3,
				Duration = new TimeSpan(0, 3, 12),
				AlbumId = 2,
				Rating = 55,
				CopyrightId = 2,
				ForSale = true,
			},

			new Song
			{
				Id = 6,
				Artist = "Sir Sly",
				Title = "High",
				Genre = "Pop",
				GenreId = 4,
				Duration = new TimeSpan(0, 3, 49),
				AlbumId = 2,
				Rating = 66,
				CopyrightId = 3,
				ForSale = false,
			},

			new Song
			{
				Id = 7,
				Artist = "Jungle",
				Title = "Busy Earnin'",
				Genre = "Pop Disco",
				GenreId = 6,
				Duration = new TimeSpan(0, 2, 28),
				AlbumId = 2,
				Rating = 77,
				CopyrightId = 1,
				ForSale = true,
			},

			new Song
			{
				Id = 8,
				Artist = "Bignic",
				Title = "Gladius",
				Genre = "Television OST",
				GenreId = 7,
				Duration = new TimeSpan(0, 5, 26),
				AlbumId = 3,
				Rating = 88,
				CopyrightId = 2,
				ForSale = false,
			},

			new Song
			{
				Id = 9,
				Artist = "In Quantum",
				Title = "Odyssey",
				Genre = "Ambient",
				GenreId = 8,
				Duration = new TimeSpan(0, 4, 6),
				AlbumId = null,
				Rating = 99,
				CopyrightId = 3,
				ForSale = true,
			},

			new Song
			{
				Id = 10,
				Artist = "Fatboy Slim",
				Title = "Bird of Prey",
				Genre = "Pop Electronic",
				GenreId = 3,
				Duration = new TimeSpan(0, 3, 46),
				AlbumId = 2,
				Rating = 11,
				CopyrightId = 1,
				ForSale = true,
			},

			new Song
			{
				Id = 11,
				Artist = "Ivan Torrent",
				Title = "Architects of Life (Feat. Celica Soldream)",
				Genre = "Classic Electronic",
				GenreId = 9,
				Duration = new TimeSpan(0, 4, 54),
				AlbumId = 3,
				Rating = 22,
				CopyrightId = 2,
				ForSale = true,
			}
		};
	}
}
