using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetPracticeExamples.Data;
using System.Collections.Generic;
using System.Linq;
using DotNetPracticeExamples.Services.IService;
using DotNetPracticeExamples.Models;

namespace DotNetPracticeExamples.Controllers
{
	//- '[controller]' is a wildcard for the below 
	//[Route("api//SongsController/[controller]")]
	[Route("api/SongsController")]
	[ApiController]
	public class SongsController : ControllerBase
	{
		private ISongService _songSevice;

		public SongsController(ISongService songService)
		{ _songSevice = songService; }


		/// /////////// Get All Songs ///////////
		[HttpGet("GetAllSongs")]
		public IActionResult GetAllSongs()
		{
			var result = _songSevice.GetAllSongs();

			if (result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs by Genre ///////////
		[HttpGet("GetSongsByGenre/{genre}")]
		public IActionResult GetSongsByGenre(string genre)
		{
			var result = _songSevice.GetSongsByGenre(genre);

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs by Rating Greater Than ///////////
		[HttpGet("GetSongsByRatingGreaterThan/{rating}")]
		public IActionResult GetSongsByRatingGreaterThan(int rating)
		{
			var result = _songSevice.GetSongsByRatingGreaterThan(rating);

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs By Duration ///////////
		[HttpGet("GetSongsByDurationGreaterThan/{duration}")]
		public IActionResult GetSongsByDurationGreaterThan(int duration)
		{
			var result = _songSevice.GetSongsByDurationGreaterThan(duration);

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs Paginated ///////////
		[HttpGet("GetSongsPagniated/{pageIndex}&{pageSize}")]
		public IActionResult GetSongsPagniated(int pageIndex, int pageSize)
		{
			var result = _songSevice.GetSongsPagniated(pageIndex, pageSize);

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs Joined With Album Name ///////////
		[HttpGet("GetAllSongsJoinedWithAlbumName")]
		public IActionResult GetAllSongsJoinedWithAlbumName()
		{
			var result = _songSevice.GetAllSongsJoinedWithAlbumName();

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}

		/// /////////// Get All Songs By Genre ///////////
		[HttpGet("GetAllSongsByGenre")]
		public IActionResult GetAllSongsByGenre()
		{
			var result = _songSevice.GetAllSongsByGenre();

			if(result != null)
			{ return StatusCode(200, result); }
			else
			{ return StatusCode(404, "No results found"); }
		}
	}
}
