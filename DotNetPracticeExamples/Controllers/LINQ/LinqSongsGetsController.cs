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

		/// /////////// Get By Id and return 'IActionResult' ///////////
		[HttpGet("GetByIdIActionResult/id={id}")]
		public IActionResult GetByIdIActionResult(int id)
		{
			var song = _dbContext.Songs.Where((element) => element.Id == id);

			if(song == null)
			{
				return StatusCode(404, $"Id: {id} not found.");
			}
			else
			{
				return StatusCode(200, song);
			}
		}

		/// /////////// Get By Id and return 'IActionResult' ///////////
		//[HttpGet("GetByDurationIActionResult/durationGreaterThan={durationGreaterThan}")]
		//public IActionResult GetByDurationIActionResult(string durationGreaterThan)
		//{ 
		//	var song = _dbContext.Songs.Where((element) => element.Duration > durationGreaterThan).

		//	if(song == null)
		//	{
		//		return StatusCode(404, $"No song with duration greather than {durationGreaterThan} found.");
		//	}
		//	else
		//	{
		//		return StatusCode(200, song);
		//	}
		//}
	}
}
