using Microsoft.EntityFrameworkCore;
using DotNetPracticeExamples.Models;

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

		//Add entries to database upon 'database-update'
		/*
		//Override method of 'DbContext' class '.OnModelCreating()' to add database entries upon database creation
		//- 'ModelBuilder' (.NET extension of 'EntityFrameworkCore' class) -- Used to construct the shape and relationships of a model for a context
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Song>().HasData(
				new Song
				{ 
					Id = 1,
					Title = "Default Song 1",
					Language = "Default Language 1",
					Duration = "1:23"		
				},

				new Song
				{
					Id = 2,
					Title = "Default Song 2",
					Language = "Default Language 2",
					Duration = "2:34"
				},

				new Song
				{
					Id = 3,
					Title = "Default Song 3",
					Language = "Default Language 3",
					Duration = "3:45"
				}
			);
		}
		*/
	}
}
