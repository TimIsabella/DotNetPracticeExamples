using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetPracticeExamples.Models;
using DotNetPracticeExamples.Data;
using DotNetPracticeExamples.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetPracticeExamples.Controllers
{
	//URL 'Route' -- https://localhost:1234/api/controllername
	//- '[controller]' is a wildcard for the below -- for a GET, 'songs' would be used in place of it to return songs
	//[Route("api/[controller]")]
	[Route("api/SongsGetSimpleController")]
	[ApiController]
	public class SongsGetSimpleController : ControllerBase
	{
		private ApiDbContext _dbContext;

		public SongsGetSimpleController(ApiDbContext dbContext)
		{ _dbContext = dbContext; }

		/// //////////////////////////////////////////// GET ALL EXAMPLES ////////////////////////////////////////////

		/// /////////// 'IEnumerable' Return ///////////
		[HttpGet("GetAllIEnumerable")]
		public IEnumerable<Song> GetAllIEnumerable() //Extend 'songs' List with IEnumerable extensions
		{
			return _dbContext.Songs; //Rerturn JSON list of songs to client
		}

		/// /////////// 'IActionResult' Return ///////////
		[HttpGet("GetAllIActionResult")]
		public IActionResult GetAllIActionResult() // 'IActionResult' (.NET interface of 'Mvc' class) -- Defines a contract that represents the result of an action method
		{
			return StatusCode(200, _dbContext.Songs);
		}

		/// //////////////////////////////////////////// GET BY EXAMPLES ////////////////////////////////////////////

		/// /////////// Simple Int Return ///////////
		//- Gets an int from url and returns it to the client
		[HttpGet("GetIntReturn/{returnInt}")]
		public int GetReturnInt(int returnInt)
		{
			return returnInt;
		}

		/// /////////// Get By Id and return 'dbContext' of model ///////////
		//- 'Song' model return does not support 'ControllerBase' and must be returned separately
		[HttpGet("GetByIdSingleModel/{id}")]
		public Song GetByIdSingleModel(int id)
		{
			var song = _dbContext.Songs.Find(id);

			if(song == null)
			{
				NotFound($"Id: {id} not found");
				return song; 
			}
			else
			{
				StatusCode(200);
				return song;
			}
		}

		/// /////////// Get By Id and return 'IActionResult' ///////////
		[HttpGet("GetByIdIActionResult/{id]")]
		public IActionResult GetByIdIActionResult(int id)
		{
			var song = _dbContext.Songs.Find(id);

			if(song == null)
			{
				return NotFound($"Id: {id} not found");
			}
			else
			{
				return StatusCode(200, song);
			}
		}
	}
}
