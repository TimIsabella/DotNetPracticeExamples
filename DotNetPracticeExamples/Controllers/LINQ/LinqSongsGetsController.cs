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

		/// ///////////////////////////////// GET ALL EXAMPLES WITH LINQ /////////////////////////////////

		/// /////////// Get All Songs ///////////
		[HttpGet("GetAllSongs")]
		public IActionResult GetAllSongs()
		{
			var result = from song in _dbContext.Songs
						 orderby song.Artist ascending
						 select new { 
										Artist = song.Artist, 
										Title = song.Title, 
										Duration = song.Duration
									};

			return StatusCode(200, result);
		}

		/// /////////// Get All Songs Joined With Album ///////////
		[HttpGet("GetAllSongsJoinedWithAlbum")]
		public IActionResult GetAllSongsJoinedWithAlbum()
		{
			var result = from song in _dbContext.Songs
						 join album in _dbContext.Albums
						 on song.AlbumId equals album.Id
						 orderby album.Title ascending
						 select new { 
										Artist = song.Artist,
										Title = song.Title, 
										Album = album.Title,
										Duration = song.Duration
									};

			return StatusCode(200, result);
		}

		/// /////////// Get By Id and return 'IActionResult' ///////////
		[HttpGet("GetAllSongsOfAlbum")]
		public IActionResult GetAllSongsOfAlbum()
		{
			IQueryable result = from album in _dbContext.Albums
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

			return StatusCode(200, result);
		}
	}
}
