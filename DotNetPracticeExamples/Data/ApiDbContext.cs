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
		public DbSet<Album> Albums { get; set; }
		public DbSet<SongWithImage> SongsWithImage { get; set; }
		public DbSet<Genre> Genre { get; set; }

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
					StatusId = 1,
					ForSale = true		
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
					StatusId = 2,
					ForSale = false
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
					StatusId = 3,
					ForSale = true
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
					StatusId = 1,
					ForSale = false
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
					StatusId = 2,
					ForSale = true
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
					StatusId = 3,
					ForSale = false
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
					StatusId = 1,
					ForSale = true
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
					StatusId = 2,
					ForSale = false
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
					StatusId = 3,
					ForSale = true
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
					StatusId = 1,
					ForSale = true
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
					StatusId = 2,
					ForSale = true
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
					ForSale = true
				},

				new Album
				{
					Id = 2,
					Title = "Popular Album",
					Genre = "Pop",
					GenreId = 4,
					CoverArtUrl = "https://www.popwebsite.com/coverart.jpg",
					StatusId = 2,
					ForSale = false
				},

				new Album
				{
					Id = 3,
					Title = "Mix Album",
					Genre = "Various",
					GenreId = 10,
					CoverArtUrl = "https://www.mixalbum.com/coverart.jpg",
					StatusId = 3,
					ForSale = true
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
		}
	}
}
