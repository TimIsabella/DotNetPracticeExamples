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
	public class LinqAlbumsGetsController : ControllerBase
	{
		private ApiDbContext _dbContext;

		public LinqAlbumsGetsController(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		/// ///////////////////////////////// GET EXAMPLES WITH LINQ /////////////////////////////////
		/// - Available keywords in query syntax:
		/// From, Select, Join, Aggregate, Union, Distinct, Take, Skip, In, Group, OrderBy, ThenBy, Reverse, Let, Into, DefaultIfEmpty, Where, Count, Sum, Min, Max, Average

		/// - Available extension methods in method syntax (most common):
		/// Select, Where, OrderBy, OrderByDescending, ThenBy, ThenByDescending, Join, GroupJoin, GroupBy, Distinct, Concat, Union, Intersect, Except, Zip, Skip, SkipWhile, 
		/// Take, TakeWhile, Reverse, ToArray, ToList, ToDictionary, ToLookup, AsEnumerable, Cast, OfType, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault, 
		/// ElementAt, Min, Max, Average, Sum, Aggregate


		/// /////////// Get All Albums And List Songs ///////////
		[HttpGet("GetAllSongsOfAlbum")]
		public IActionResult GetAllSongsOfAlbum()
		{
			///Query Syntax
			var queryResult = from album in _dbContext.Albums
							  orderby album.Title ascending
							  select new
							  {
								  Album = album.Title,
								  Genre = album.Genre,

								  //List of songs in album
								  Songs = (from song in _dbContext.Songs
										   where song.AlbumId == album.Id
										   orderby song.Artist ascending
										   select new
										   {
											   Artist = song.Artist,
											   Title = song.Title,
											   Duration = song.Duration.ToString(@"mm\:ss")
										   }).ToList() //Returns multiple results and must be converted to a list
							  };

			///Method Syntax
			var methodResult = _dbContext.Albums
							  .OrderBy(album => album.Title)
							  .Select(album => new
							  {
								  Album = album.Title,
								  Genre = album.Genre,

								  //List of songs in album
								  Songs = _dbContext.Songs
										  .Where(song => song.AlbumId == album.Id)
										  .OrderBy(song => song.Artist)
										  .Select(song => new
										  {
											  Artist = song.Artist,
											  Title = song.Title,
											  Duration = song.Duration.ToString(@"mm\:ss")
										  }).ToList() //Returns multiple results and must be converted to a list
							  });

			if(methodResult != null)
			{ return StatusCode(200, methodResult); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Albums With Total Duration ///////////
		[HttpGet("GetAllAlbumsWithTotalDuration")]
		public IActionResult GetAllAlbumsWithTotalDuration()
		{
			var queryResult = from album in _dbContext.Albums
							  let songList = (from song in _dbContext.Songs
											  where song.AlbumId == album.Id
											  select song
											 ).ToList()
							  select new
							  {
								  Album = album.Title,
								  ///Create new TimeSpan based on sum total of song list duration
								  Duration = new TimeSpan(songList.Sum(song => song.Duration.Hours),    //Get Sum total of songs hours
														  songList.Sum(song => song.Duration.Minutes),  //Get Sum total of songs minutes
														  songList.Sum(song => song.Duration.Seconds)   //Get Sum total of songs seconds
														 ).ToString(@"hh\:mm\:ss"),

								  Songs = (from song in songList
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

		/// /////////// Get All Albums With Total Rating ///////////
		[HttpGet("GetAllAlbumsWithTotalRating")]
		public IActionResult GetAllAlbumsWithTotalRating()
		{
			var queryResult = from album in _dbContext.Albums
							  let songList = (from song in _dbContext.Songs
											  where song.AlbumId == album.Id
											  select song
											 ).ToList()

							  select new
							  {
								  Album = album.Title,
								  Rating = songList.Sum(song => song.Rating) / songList.Count
							  };

			if(queryResult != null)
			{ return StatusCode(200, queryResult); }
			else
			{ return StatusCode(404, "No results found"); }
		}
	}
}
