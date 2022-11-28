using Microsoft.AspNetCore.Mvc;
using DotNetPracticeExamples.Services.IService;
using System.Collections;
using System;
using DotNetPracticeExamples.Models;
using Microsoft.EntityFrameworkCore;

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
			IEnumerable result = null;
			
			try
			{
				result = _songSevice.GetAllSongs();

				if(result != null)
				{ return StatusCode(200, result); }
				else
				{ return StatusCode(404, "No results found"); }
			}

			catch(Exception ex)
			{ 
				return StatusCode(500, ex.Message.ToString());
			}
		}

		/// /////////// Get All Songs by Genre ///////////
		[HttpGet("GetSongsByGenre/{genre}")]
		public IActionResult GetSongsByGenre(string genre)
		{
			IEnumerable result = null;

			try
			{
				result = _songSevice.GetSongsByGenre(genre);

				if(result != null)
				{ return StatusCode(200, result); }
				else
				{ return StatusCode(404, "No results found"); }
			}

			catch(Exception ex)
			{
				return StatusCode(500, ex.Message.ToString());
			}
		}

		/// /////////// Get All Songs by Rating Greater Than ///////////
		[HttpGet("GetSongsByRatingGreaterThan/{rating}")]
		public IActionResult GetSongsByRatingGreaterThan(int rating)
		{
			IEnumerable result = null;

			try
			{
				result = _songSevice.GetSongsByRatingGreaterThan(rating);

				if(result != null)
				{ return StatusCode(200, result); }
				else
				{ return StatusCode(404, "No results found"); }
			}

			catch(Exception ex)
			{
				return StatusCode(500, ex.Message.ToString());
			}
		}

		/// /////////// Get All Songs By Duration /////////// 
		[HttpGet("GetSongsByDurationGreaterThan/{duration}")]
		public IActionResult GetSongsByDurationGreaterThan(int duration)
		{
			IEnumerable result = null;

			try
			{
				result = _songSevice.GetSongsByDurationGreaterThan(duration);

				if(result != null)
				{ return StatusCode(200, result); }
				else
				{ return StatusCode(404, "No results found"); }
			}

			catch(Exception ex)
			{
				return StatusCode(500, ex.Message.ToString());
			}
		}

		/// /////////// Get All Songs Paginated ///////////
		[HttpGet("GetSongsPagniated/{pageIndex}&{pageSize}")]
		public IActionResult GetSongsPagniated(int pageIndex, int pageSize)
		{
			IEnumerable result = null;

			try
			{
				result = _songSevice.GetSongsPagniated(pageIndex, pageSize);

				if(result != null)
				{ return StatusCode(200, result); }
				else
				{ return StatusCode(404, "No results found"); }
			}

			catch(Exception ex)
			{
				return StatusCode(500, ex.Message.ToString());
			}
		}

		/// /////////// Get All Songs Joined With Album Name ///////////
		[HttpGet("GetAllSongsJoinedWithAlbumName")]
		public IActionResult GetAllSongsJoinedWithAlbumName()
		{
			IEnumerable result = null;

			try
			{
				result = _songSevice.GetAllSongsJoinedWithAlbumName();

				if(result != null)
				{ return StatusCode(200, result); }
				else
				{ return StatusCode(404, "No results found"); }
			}

			catch(Exception ex)
			{
				return StatusCode(500, ex.Message.ToString());
			}
		}

		/// /////////// Get All Songs By Genre ///////////
		[HttpGet("GetAllSongsByGenre")]
		public IActionResult GetAllSongsByGenre()
		{
			IEnumerable result = null;

			try
			{
				result = _songSevice.GetAllSongsByGenre();

				if(result != null)
				{ return StatusCode(200, result); }
				else
				{ return StatusCode(404, "No results found"); }
			}

			catch(Exception ex)
			{
				return StatusCode(500, ex.Message.ToString());
			}
		}

		[HttpGet("GetAllSongsWithDistributor")]
		public IActionResult GetAllSongsWithDistributor()
		{
			IEnumerable result = null;

			try
			{
				result = _songSevice.GetAllSongsWithDistributor();

				if(result != null)
				{ return StatusCode(200, result); }
				else
				{ return StatusCode(404, "No results found"); }
			}

			catch(Exception ex)
			{
				return StatusCode(500, ex.Message.ToString());
			}
		}

		[HttpPost("PostSong")]
		public IActionResult Post([FromForm] Song song)
		{
			int? result = null;

			try
			{
				result = _songSevice.Post(song);

				if(result != null)
				{ return StatusCode(201, result); }
				else
				{ return StatusCode(400, "Bad request -- Record not created"); }
			}

			catch(Exception ex)
			{
				return StatusCode(500, ex.Message.ToString());
			}
		}

		[HttpPut("UpdateSong")]
		public IActionResult Put(int id, [FromForm] Song song)
		{
			int? result = null;

			try
			{
				result = _songSevice.Put(id, song);

				if(result > 0)
				{ return StatusCode(200, result); }
				else
				{ return StatusCode(400, "Bad request -- Record not updated"); }
			}

			catch(Exception ex)
			{
				return StatusCode(500, ex.Message.ToString());
			}
		}


		[HttpDelete("DeleteById")]
		public IActionResult DeleteById(int id)
		{
			int? result = 0;

			try
			{
				result = _songSevice.DeleteById(id);

				if(result > 0)
				{ return StatusCode(200, result); }
				else
				{ return StatusCode(404, "No record found for deletion"); }
			}

			catch(Exception ex)
			{
				return StatusCode(500, ex.Message.ToString());
			}
		}
	}
}
