using Microsoft.AspNetCore.Mvc;
using DotNetPracticeExamples.Data;
using System.Linq;
using System;
using DotNetPracticeExamples.Services.IService;
using System.Collections.Generic;
using DotNetPracticeExamples.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetPracticeExamples.Controllers.ByRepository
{
	//URL 'Route' -- https://localhost:1234/api/SongsGets
	//- '[controller]' is a wildcard for the below -- for a GET, 'songs' would be used in place of it to return songs
	//[Route("api/[controller]")]
	[Route("api/AlbumsController")]
	[ApiController]
	public class AlbumsController : ControllerBase
	{
		private IAlbumService _albumService;

		public AlbumsController(IAlbumService albumService)
		{
			_albumService = albumService;
		}

		/// /////////// Get All Albums And List Songs ///////////
		[HttpGet("GetAllAlbums")]
		public IActionResult GetAllAlbums()
		{
			///Query Syntax
			var result = _albumService.GetAllAlbums();

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Albums And List Songs ///////////
		[HttpGet("GetAllSongsOfAlbum")]
		public IActionResult GetAllSongsOfAlbum()
		{
			var result = _albumService.GetAllSongsOfAlbum();

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Albums With Total Duration ///////////
		[HttpGet("GetAllAlbumsWithTotalDuration")]
		public IActionResult GetAllAlbumsWithTotalDuration()
		{
			var result = _albumService.GetAllAlbumsWithTotalDuration();

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Albums With Average Rating ///////////
		[HttpGet("GetAllAlbumsWithAverageRating")]
		public IActionResult GetAllAlbumsWithAverageRating()
		{
			var queryResult = _albumService.GetAllAlbumsWithAverageRating();

			if(queryResult != null)
			{ return StatusCode(200, queryResult); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Albums With Formats ///////////
		[HttpGet("GetAllAlbumsWithFormats")]
		public IActionResult GetAllAlbumsWithFormats()
		{
			var queryResult = _albumService.GetAllAlbumsWithFormats();

			if(queryResult != null)
			{ return StatusCode(200, queryResult); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Albums With Formats and Distributors ///////////
		[HttpGet("GetAllAlbumsWithFormatsAndDistributors")]
		public IActionResult GetAllAlbumsWithFormatsAndDistributors()
		{
			var queryResult = _albumService.GetAllAlbumsWithFormatsAndDistributors();

			if(queryResult != null)
			{ return StatusCode(200, queryResult); }
			else
			{ return StatusCode(404, "No results found"); }
		}
	}
}
