using Microsoft.EntityFrameworkCore;
using DotNetPracticeExamples.Models;
using System;

namespace DotNetPracticeExamples.Data
{
	public class ApiDbContext : DbContext //Inheriting 'DbContext' (.NET extension of 'EntityFrameworkCore' class) -- Responsible for all SQL CRUD operations
	{
		//Constructor with 'DbContextOptions' from 'DbContext' passed into constructor
		//- 'DbContextOptions' (.NET extension of 'EntityFrameworkCore' class) -- Carries configuration information such as the connection string, database provider to use etc.
		//- 'options' is passed to the 'base' constructor of 'DbContext'
		public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
		{ }

		//'DbSet' (.NET extension of 'EntityFrameworkCore' class) -- Maps / creates database tables
		//- Property will be mapped to table of 'Songs' with columns from 'Song' model
		public DbSet<Song> Songs { get; set; }
		public DbSet<SongWithImage> SongsWithImage { get; set; }
		public DbSet<Album> Albums { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Copyright> Status { get; set; }
		public DbSet<Distributor> Distributors { get; set; }
		public DbSet<Format> Formats { get; set; }

		//Add entries to database upon 'database-update'
		//Override method of 'DbContext' class '.OnModelCreating()' to add database entries upon database creation
		//- 'ModelBuilder' (.NET extension of 'EntityFrameworkCore' class) -- Used to construct the shape and relationships of a model for a context
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Songs
			modelBuilder.Entity<Song>().HasData(
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
					Formats = new int[] { 1, 2 },
					Distributors = new int[] { 2, 3, 4, 5}
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
					Formats = new int[] { 1, 2 },
					Distributors = new int[] { 2, 3, 4, 5 }
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
					Formats = new int[] { 1, 2 },
					Distributors = new int[] { 2, 3, 4, 5 }
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
					Formats = new int[] { 1, 2 },
					Distributors = new int[] { 2, 3, 4, 5 }
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
					Formats = new int[] { 1, 2, 3},
					Distributors = new int[] { 2, 3, 4 }
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
					Formats = new int[] { 1, 2, 3 },
					Distributors = new int[] { 2, 3, 4 }
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
					Formats = new int[] { 1, 3, 4 },
					Distributors = new int[] { 1, 2, 3, 5 }
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
					Formats = new int[] { 1 },
					Distributors = new int[] { 2, 5 }
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
					Formats = new int[] { 1 },
					Distributors = new int[] { 3, 5 }
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
					Formats = new int[] { 1, 2 },
					Distributors = new int[] { 2, 3, 4, 5 }
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
					Formats = new int[] { 1 },
					Distributors = new int[] { 5 }
				}
			);

			//Albums
			modelBuilder.Entity<Album>().HasData(
				new Album
				{
					Id = 1,
					Title = "Psytrance Album",
					Genre = "Psytrance",
					GenreId = 1,
					CoverArtUrl = "https://www.website.com/coverart.jpg",
					StatusId = 1,
					ForSale = true,
					Formats = new int[] { 1, 2 },
					Distributors = new int[] { 2, 3, 4, 5 }
				},

				new Album
				{
					Id = 2,
					Title = "Popular Album",
					Genre = "Pop",
					GenreId = 4,
					CoverArtUrl = "https://www.popwebsite.com/coverart.jpg",
					StatusId = 2,
					ForSale = false,
					Formats = new int[] { 2, 3, 4 }
				},

				new Album
				{
					Id = 3,
					Title = "Mix Album",
					Genre = "Various",
					GenreId = 10,
					CoverArtUrl = "https://www.mixalbum.com/coverart.jpg",
					StatusId = 3,
					ForSale = true,
					Formats = new int[] { 1, 2, 3, 4 },
					Distributors = new int[] { 1, 4 }
				}
			);

			//Genres
			modelBuilder.Entity<Genre>().HasData(
				new Genre
				{
					Id = 1,
					GenreType = "Psytrance",
					Rating = 11
				},

				new Genre
				{
					Id = 2,
					GenreType = "Electronic",
					Rating = 22
				},

				new Genre
				{
					Id = 3,
					GenreType = "Pop Electronic",
					Rating = 33
				},

				new Genre
				{
					Id = 4,
					GenreType = "Pop",
					Rating = 44
				},

				new Genre
				{
					Id = 5,
					GenreType = "Disco",
					Rating = 55
				},

				new Genre
				{
					Id = 6,
					GenreType = "Pop Disco",
					Rating = 66
				},

				new Genre
				{
					Id = 7,
					GenreType = "Television OST",
					Rating = 77
				},

				new Genre
				{
					Id = 8,
					GenreType = "Ambient",
					Rating = 88
				},

				new Genre
				{
					Id = 9,
					GenreType = "Classic Electronic",
					Rating = 99
				},

				new Genre
				{
					Id = 10,
					GenreType = "Various",
					Rating = 11
				},

				new Genre
				{
					Id = 11,
					GenreType = "Other",
					Rating = 22
				}
			);

			//Statuses
			modelBuilder.Entity<Copyright>().HasData(
				new Copyright
				{
					Id = 1,
					Type = "Licensing"
				},

				new Copyright
				{
					Id = 2,
					Type = "Fair Use"
				},
				new Copyright
				{
					Id = 3,
					Type = "Derivative Works"
				},
				new Copyright
				{
					Id = 4,
					Type = "Orphaned Works"
				},
				new Copyright
				{
					Id = 5,
					Type = "Public Domain"
				}
			);

			//Distributors
			modelBuilder.Entity<Distributor>().HasData(
				new Distributor
				{
					Id = 1,
					Name = "Classic Records",
					City = "Classic City",
					State = "CA",
					Address = "123 Fake St",
					ZipCode = 90210
				},
				new Distributor
				{
					Id = 2,
					Name = "DigiMusic",
					Url = "https://www.digimusic.com",
					City = "Another City",
					State = "VA",
					Address = "PO Box 1234",
					ZipCode = 23723
				},
				new Distributor
				{
					Id = 3,
					Name = "Super Downloads",
					Url = "https://www.superdownloads.com"
				},
				new Distributor
				{
					Id = 4,
					Name = "Great Music Distro",
					Url = "https://www.GMD.com",
					City = "Las Vegas",
					State = "NV",
					Address = "123 Sunset Blvd.",
					ZipCode = 89123
				},
				new Distributor
				{
					Id = 5,
					Name = "Cheap Music Digital",
					Url = "https://www.CheapSongs.com"
				}
			);

			//Formats
			modelBuilder.Entity<Format>().HasData(
				new Format
				{
					Id = 1,
					Type = "Digital Download"
				},
				new Format
				{
					Id = 2,
					Type = "Compact Disc"
				},
				new Format
				{
					Id = 3,
					Type = "Cassette Tape"
				},
				new Format
				{
					Id = 4,
					Type = "Record"
				},
				new Format
				{
					Id = 5,
					Type = "Other"
				}
			);
		}
	}
}
