using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

		/// /////////// Get All Songs ///////////
		[HttpGet("GetAllSongs")]
		public IActionResult GetAllSongs()
		{
			///Query syntax
			var result = from song in _dbContext.Songs
						 orderby song.Artist ascending
						 select new
						 {
							 Artist = song.Artist,
							 Title = song.Title,
							 Duration = song.Duration
						 };

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs Joined With Album ///////////
		[HttpGet("GetAllSongsJoinedWithAlbum")]
		public IActionResult GetAllSongsJoinedWithAlbum()
		{
			///Query syntax
			var result = from song in _dbContext.Songs
						 join album in _dbContext.Albums
						 on song.AlbumId equals album.Id
						 orderby album.Title ascending
						 select new
						 {
							 Artist = song.Artist,
							 Title = song.Title,
							 Album = album.Title,
							 Duration = song.Duration
						 };

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Albums And List Songs ///////////
		[HttpGet("GetAllSongsOfAlbum")]
		public IActionResult GetAllSongsOfAlbum()
		{
			///Query syntax
			var result = from album in _dbContext.Albums
						 orderby album.Title ascending
						 select new
						 {
							 Album = album.Title,
							 Genre = album.Genre,

							 //List of songs
							 Songs = (
										from song in _dbContext.Songs
										where song.AlbumId == album.Id
										orderby song.Artist ascending
										select new
										{
											Artist = song.Artist,
											Title = song.Title,
											Duration = song.Duration
										}
									).ToList() //Returns multiple results and must be converted to a list
						 };

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs by Rating ///////////
		[HttpGet("GetSongsByRating/rating={rating}")]
		public IActionResult GetSongsByRating(int rating)
		{
			///Query syntax
			var result = from song in _dbContext.Songs
						 where song.Rating >= rating
						 orderby song.Title ascending
						 select song;

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs by Rating ///////////
		[HttpGet("GetSongsByGenre/genre={genre}")]
		public IActionResult GetSongsByGenre(string genre)
		{
			///Query syntax
			var result = from song in _dbContext.Songs
						 where EF.Functions.Like(song.Genre, $"%{genre}%") //Directly 'LIKE' operator in SQL -- LINQ does not contain a LIKE operator
						 orderby song.Title ascending
						 select song;

			if(result != null)
			{ return StatusCode(200, result); }
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
							   .Skip((pageIndex - 1) * pageSize)	//Query syntax does not have skip
							   .Take(pageSize);                     //Query syntax does not have take

			///Method syntax
			//Get all songs
			var allSongs = _dbContext.Songs;

			//'Skip' songs elements by pagination formula
			//- formula establishes proper element start position
			//- Example:
			//-- Page 1 with 3 results: 0 * 3 = 0 -- 0 index starting point
			//-- Page 2 with 3 results: 1 * 3 = 3 -- 3 index starting point
			//-- Page 3 with 3 results: 2 * 3 = 6 -- 6 index starting point
			var skippedSongs = allSongs.Skip((pageIndex - 1) * pageSize);

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
	}
}
