using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace DotNetPracticeExamples.Controllers
{
	//URL 'Route' -- https://localhost:1234/api/SongsGets
	//- '[controller]' is a wildcard for the below -- for a GET, 'songs' would be used in place of it to return songs
	//[Route("api/[controller]")]
	[Route("api/LinqSongsGets")]
	[ApiController]
	public class LinqSongsGetsController : ControllerBase
	{
		private ApiDbContext _dbContext;

		public LinqSongsGetsController(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		/// ///////////////////////////////// GET EXAMPLES WITH LINQ /////////////////////////////////
		/// - Available keywords in query syntax:
		/// From, Select, Join, Aggregate, Union, Distinct, Take, Skip, In, Group, OrderBy, ThenBy, Reverse, Let, Into, DefaultIfEmpty, Where, Count, Sum, Min, Max, Average

		/// - Available extension methods in method syntax (most common):
		/// Select, Where, OrderBy, OrderByDescending, ThenBy, ThenByDescending, Join, GroupJoin, GroupBy, Distinct, Concat, Union, Intersect, Except, Zip, Skip, SkipWhile, 
		/// Take, TakeWhile, Reverse, ToArray, ToList, ToDictionary, ToLookup, AsEnumerable, Cast, OfType, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault, 
		/// ElementAt, Min, Max, Average, Sum, Aggregate


		/// /////////// Get All Songs ///////////
		[HttpGet("GetAllSongs")]
		public IActionResult GetAllSongs()
		{
			///Query syntax
			var queryResult = from song in _dbContext.Songs
							  select song;                   //'select' with no properties returns all information

			var methodResult = _dbContext.Songs;             //No select returns all information

			if(methodResult != null)
			{ return StatusCode(200, methodResult); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs by Genre ///////////
		[HttpGet("GetSongsByGenre/genre={genre}")]
		public IActionResult GetSongsByGenre(string genre)
		{
			///Query Syntax
			var queryResult = from song in _dbContext.Songs
							  where EF.Functions.Like(song.Genre, $"%{genre}%") //Directly 'LIKE' operator in SQL -- LINQ does not contain a LIKE operator
							  orderby song.Title ascending
							  select new
							  {
								  Artist = song.Artist,
								  Title = song.Title,
								  Duration = song.Duration.ToString(@"mm\:ss") //Break down TimeSpan duration to 01:23 time format
							  };

			///Method Syntax
			var methodResult = _dbContext.Songs
							   .Where(song => EF.Functions.Like(song.Genre, $"%{genre}%"))
							   .OrderBy(song => song.Title)
							   .Select(song => new
							   {
								   Artist = song.Artist,
								   Title = song.Title,
								   Duration = song.Duration.ToString(@"mm\:ss") //Break down TimeSpan duration to 01:23 time format
							   });

			if(methodResult != null)
			{ return StatusCode(200, methodResult); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs by Rating Greater Than ///////////
		[HttpGet("GetSongsByRatingGreaterThan/rating={rating}")]
		public IActionResult GetSongsByRatingGreaterThan(int rating)
		{
			///Query Syntax
			var queryResult = from song in _dbContext.Songs
							  where song.Rating >= rating
							  orderby song.Title ascending
							  select new
							  {
								  Artist = song.Artist,
								  Title = song.Title,
								  Duration = song.Duration.ToString(@"mm\:ss")
							  };

			///Method Syntax
			var methodResult = _dbContext.Songs
							   .Where(song => song.Rating >= rating)
							   .OrderBy(song => song.Title)
							   .Select(song => new
							   {
								   Artist = song.Artist,
								   Title = song.Title,
								   Duration = song.Duration.ToString(@"mm\:ss")
							   });

			if(methodResult != null)
			{ return StatusCode(200, methodResult); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs By Duration ///////////
		[HttpGet("GetSongsByDurationGreaterThan/duration={duration}")]
		public IActionResult GetSongsByDurationGreaterThan(int duration)
		{
			var queryResult = from song in _dbContext.Songs
							  where song.Duration.Minutes >= duration
							  orderby song.Duration.Minutes
							  select new
							  {
								  Artist = song.Artist,
								  Title = song.Title,
								  Duration = song.Duration.ToString(@"mm\:ss")
							  };

			if(queryResult != null)
			{ return StatusCode(200, queryResult); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs Paginated ///////////
		[HttpGet("GetSongsPagniated/pageIndex={pageIndex}&pageSize={pageSize}")]
		public IActionResult GetSongsPagniated(int pageIndex, int pageSize)
		{
			///Query Syntax
			var queryResult = (from song in _dbContext.Songs
							   select song)
							   .Skip((pageIndex - 1) * pageSize)    //Query syntax does not have skip
							   .Take(pageSize);                     //Query syntax does not have take

			///Method Syntax
			//'Skip' songs elements by pagination formula
			//- formula establishes proper element start position
			//- Example:
			//-- Page 1 with 3 results: 0 * 3 = 0 -- 0 index starting point
			//-- Page 2 with 3 results: 1 * 3 = 3 -- 3 index starting point
			//-- Page 3 with 3 results: 2 * 3 = 6 -- 6 index starting point
			var skippedSongs = _dbContext.Songs.Skip((pageIndex - 1) * pageSize);

			//'Take' elements by size
			var takeSongs = skippedSongs.Take(pageSize);

			//Same as above in one line
			var methodResult = _dbContext.Songs
							   .Skip((pageIndex - 1) * pageSize)
							   .Take(pageSize);

			if(methodResult != null)
			{ return StatusCode(200, methodResult); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs Joined With Album Name ///////////
		[HttpGet("GetAllSongsJoinedWithAlbumName")]
		public IActionResult GetAllSongsJoinedWithAlbumName()
		{
			///Query Syntax
			var queryResult = from song in _dbContext.Songs
							  join album in _dbContext.Albums
							  on song.AlbumId equals album.Id
							  orderby album.Title ascending
							  select new
							  {
								  Artist = song.Artist,
								  Title = song.Title,
								  Album = album.Title,
								  Duration = song.Duration.ToString(@"mm\:ss")
							  };

			///Method Syntax
			var methodResult = _dbContext.Songs
							   .Join(_dbContext.Albums,
									 song => song.AlbumId,    //Serves as the 'Where' clause
									 album => album.Id,       //Serves as the 'Where' clause
									 (song, album) => new
									 {
										 Song = song,
										 Album = album
									 })
							   //.Where(joinResult => joinResult.Song.AlbumId == joinResult.Album.Id)
							   .OrderBy(result => result.Album.Title)
							   .Select(result => new
							   {
								   Artist = result.Song.Artist,
								   Title = result.Song.Title,
								   Album = result.Album.Title,
								   Duration = result.Song.Duration.ToString(@"mm\:ss")
							   });

			if(methodResult != null)
			{ return StatusCode(200, methodResult); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Genres ///////////
		[HttpGet("GetAllGenres")]
		public IActionResult GetAllGenres()
		{
			var queryResult = from genres in _dbContext.Genre
							  select genres;

			var methodResult = _dbContext.Genre;

			if(methodResult != null)
			{ return StatusCode(200, methodResult); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs By Genre ///////////
		[HttpGet("GetAllSongsByGenre")]
		public IActionResult GetAllSongsByGenre()
		{
			var queryResult = from genre in _dbContext.Genre
							  select new 
							  {
									Genre = genre,
									Songs = (from song in _dbContext.Songs
											 where song.GenreId == genre.Id
											 orderby song.Artist ascending
											 select new
											 {
												 Artist = song.Artist,
												 Title = song.Title,
												 Duration = song.Duration.ToString(@"mm\:ss")
											 }).ToList()
							  };

			if(queryResult != null)
			{ return StatusCode(200, queryResult); }
			else
			{ return StatusCode(404, "No results found"); }
		}
	}
}
