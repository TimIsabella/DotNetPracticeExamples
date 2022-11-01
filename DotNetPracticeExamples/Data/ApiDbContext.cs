using Microsoft.EntityFrameworkCore;
using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Models.Composites;
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

		///////////

		public DbSet<SongWithImage> SongsWithImage { get; set; }
		public DbSet<Album> Albums { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Copyright> Status { get; set; }

		//Distributor
		public DbSet<Distributor> Distributors { get; set; }
		public DbSet<SongDistributorComposite> SongDistributorComposite { get; set; }
		//public DbSet<AlbumDistributorComposite> AlbumDistributorComposite { get; set; }

		//Formats
		public DbSet<Format> Formats { get; set; }
		//public DbSet<SongFormatComposite> SongFormatComposite { get; set; }
		//public DbSet<AlbumFormatComposite> AlbumFormatComposite { get; set; }

		//Add entries to database upon 'database-update'
		//Override method of 'DbContext' class '.OnModelCreating()' to add database entries upon database creation
		//- 'ModelBuilder' (.NET extension of 'EntityFrameworkCore' class) -- Used to construct the shape and relationships of a model for a context
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Songs
			modelBuilder.Entity<Song>().HasData(SongData.Data);

			//Albums
			modelBuilder.Entity<Album>().HasData(AlbumData.Data);

			//Genres
			modelBuilder.Entity<Genre>().HasData(GenreData.Data);

			//Statuses
			modelBuilder.Entity<Copyright>().HasData(CopyrightData.Data);


			//Distributors
			modelBuilder.Entity<Distributor>().HasData(DistributorData.Data);

			//Song Distributor Composite
			modelBuilder.Entity<SongDistributorComposite>().HasData(new SongDistributorComposite
			{
				SongId = 1,
				DistributorId = 2
			});

			//Album Distributor Composite
			//modelBuilder.Entity<AlbumDistributorComposite>().HasNoKey().HasData(AlbumDistributorCompositeData.Data);


			//Formats
			modelBuilder.Entity<Format>().HasData(FormatData.Fdata);

			//Song Format Composite
			//modelBuilder.Entity<SongFormatComposite>().HasNoKey().HasData(SongFormatCompositeData.Data);

			//Album Format Composite
			//modelBuilder.Entity<AlbumFormatComposite>().HasNoKey().HasData(AlbumFormatCompositeData.Data);
		}
	}
}
